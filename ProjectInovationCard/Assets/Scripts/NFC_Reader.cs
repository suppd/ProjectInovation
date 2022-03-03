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
    public CardSounds cardSoundsScript;


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
                string result = System.Text.Encoding.Default.GetString(payLoad); // not sure if it works for all encodings, but it works for me

                tag_output_text.text = result;
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

    void PlaySounds()
    {
        if(ScanNFC() == "PowerCard.1")
        {
            cardSoundsScript.pointCardSoundElements[0].sound.Play();
        }
        if (ScanNFC() == "PowerCard.2")
        {
            cardSoundsScript.pointCardSoundElements[1].sound.Play();
        }
        if (ScanNFC() == "PowerCard.3")
        {
            cardSoundsScript.pointCardSoundElements[2].sound.Play();
        }
        if (ScanNFC() == "PowerCard.4")
        {
            cardSoundsScript.pointCardSoundElements[3].sound.Play();
        }

        if (ScanNFC() == "PowerCard.5")
        {
            cardSoundsScript.pointCardSoundElements[4].sound.Play();
        }

        if (ScanNFC() == "PowerCard.6")
        {
            cardSoundsScript.pointCardSoundElements[5].sound.Play();
        }
    }

    public void TestSounds()
    {
        cardSoundsScript.pointCardSoundElements[2].sound.Play();
    }
}
