using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class NFC_Reader : MonoBehaviour
{

    public string tagID;
    public Text tag_output_text;
    public bool tagFound = false;

    private AndroidJavaObject mActivity;
    private AndroidJavaObject mIntent;
    private string sAction;

    public Text displayText;
    public Text debugText;
    public CardSounds cardSoundsScript;
    public SoundPlayer soundplayer;

    public int[] pointPlays;
    public int[] specialPlays;

    //sound logic
    public bool alreadyPlayed = false;
    string result = "";
    string lastResult = "";

    void Start()
    {
        tag_output_text.text = "No tag...";
    }

    void Update()
    {
        //TestPoints();
        //soundplayer.PlaySound(0);
        //soundplayer.PlaySound(2);
        //soundplayer.PlaySound(4);
        soundplayer.PlaySpecialSound(0);
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!tagFound)
            {
                PlaySounds();
                CheckIfResultChanged();
                
            }
        }
    }

    string ScanNFC()
    {
        try
        {
            // Create new NFC Android object
            mActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); // Activities open apps
            mIntent = mActivity.Call<AndroidJavaObject>("getIntent");
            sAction = mIntent.Call<String>("getAction"); // resulte are returned in the Intent object
            if (sAction == "android.nfc.action.NDEF_DISCOVERED")
            {
                Debug.Log("Tag of type NDEF");
                AndroidJavaObject[] rawMsg = mIntent.Call<AndroidJavaObject[]>("getParcelableArrayExtra", "android.nfc.extra.NDEF_MESSAGES");
                AndroidJavaObject[] records = rawMsg[0].Call<AndroidJavaObject[]>("getRecords");
                byte[] payLoad = records[0].Call<byte[]>("getPayload");
                result = System.Text.Encoding.Default.GetString(payLoad); // not sure if it works for all encodings, but it works for me
                
                tag_output_text.text = result;
                //if(lastResult == result)
                //{
                //    result = "second";
                //}
                return result;
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message;
            tag_output_text.text = text;
            return text;
        }
        return "no scan";
    }

    void CheckIfResultChanged()
    {
        if (lastResult != result)
        {
            lastResult = result;
            alreadyPlayed = false;
        }
        else if (result == "second")
        {
            alreadyPlayed = false;
        }
    }

    void TestPoints()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddPlaysPoint(0);
            AddPlaysPoint(1);
            AddPlaysPoint(2);
            AddPlaysPoint(3);
            AddPlaysPoint(4);
            Debug.Log("increased point!");
        }
    }
    void PlaySounds()
    {
        if(result == "PowerCard.1" && !alreadyPlayed)
        {
            alreadyPlayed = true;
            soundplayer.PlaySound(0);
            AddPlaysPoint(0);
            //result = "stop";
        }
        if (result == "PowerCard.2" && !alreadyPlayed)
        {
            alreadyPlayed = true;
            soundplayer.PlaySound(1);
            AddPlaysPoint(1);
            //result = "stop";
        }
        if (ScanNFC() == "PowerCard.3" && !alreadyPlayed)
        {
            soundplayer.PlaySound(2);
            alreadyPlayed = true;
            AddPlaysPoint(2);
        }
        if (ScanNFC() == "PowerCard.4" && !alreadyPlayed)
        {
            soundplayer.PlaySound(3);
            alreadyPlayed = true;
            AddPlaysPoint(3);
        }

        if (ScanNFC() == "PowerCard.5" && !alreadyPlayed)
        {
            soundplayer.PlaySound(4);
            alreadyPlayed = true;
            AddPlaysPoint(4);
        }

        if (ScanNFC() == "PowerCard.6" && !alreadyPlayed)
        {
            soundplayer.PlaySound(5);
            alreadyPlayed = true;
            AddPlaysPoint(5);
        }

        if (result == "SpecialCard.1" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(0);
            alreadyPlayed = true;
            AddPlaysSpecial(0);
        }
        if (result == "SpecialCard.2" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(2);
            alreadyPlayed = true;
            AddPlaysSpecial(1);
        }
        if (result == "SpecialCard.3" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(3);
            alreadyPlayed = true;
            AddPlaysSpecial(2);
        }
        if (result == "SpecialCard.4" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(4);
            alreadyPlayed = true;
            AddPlaysSpecial(3);
        }
        if (result == "ScatterCard.1" && !alreadyPlayed)
        {
            soundplayer.PlayScatterSound();
            alreadyPlayed = true;
        }
    }

    void AddPlaysPoint(int index)
    {
        if (pointPlays[index] < 5)
        {
            pointPlays[index] ++;
        }
    }

    void AddPlaysSpecial(int index)
    {
        if (specialPlays[index] < 5)
        {
            specialPlays[index] ++;
        }
    }


    public void TestSounds()
    {
        //cardSoundsScript.pointCardSoundElements[1].sound.Play();
    }
}
