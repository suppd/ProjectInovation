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

    void PlaySounds()
    {
        if(result == "PowerCard.1" && !alreadyPlayed)
        {
            alreadyPlayed = true;
            soundplayer.PlaySound(0);
            //result = "stop";
        }
        if (result == "PowerCard.2" && !alreadyPlayed)
        {
            alreadyPlayed = true;
            soundplayer.PlaySound(1);
            //result = "stop";
        }
        if (ScanNFC() == "PowerCard.3")
        {
            soundplayer.PlaySound(2);
            alreadyPlayed = true;
        }
        if (ScanNFC() == "PowerCard.4")
        {
            soundplayer.PlaySound(3);
            alreadyPlayed = true;
        }

        if (ScanNFC() == "PowerCard.5")
        {
            soundplayer.PlaySound(4);
            alreadyPlayed = true;
        }

        if (ScanNFC() == "PowerCard.6")
        {
            soundplayer.PlaySound(5);
            alreadyPlayed = true;
        }

        if (result == "SpecialCard.1")
        {
            soundplayer.PlaySpecialSound(0);
            alreadyPlayed = true;
        }
        if (result == "SpecialCard.2")
        {
            soundplayer.PlaySpecialSound(2);
            alreadyPlayed = true;
        }
        if (result == "SpecialCard.3")
        {
            soundplayer.PlaySpecialSound(3);
            alreadyPlayed = true;
        }
        if (result == "SpecialCard.4")
        {
            soundplayer.PlaySpecialSound(4);
            alreadyPlayed = true;
        }
        if (result == "ScatterCard.1")
        {
            soundplayer.PlayScatterSound();
            alreadyPlayed = true;
        }
    }


    public void TestSounds()
    {
        //cardSoundsScript.pointCardSoundElements[1].sound.Play();
    }
}
