using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NFC_Reader : MonoBehaviour
{

    public string tagID;
    public Text tag_output_text;
    public bool tagFound = false;

    public GameObject playerManager;
    public GameObject scoreManager;
    public GameObject roundManager;

    private PlayerManager playerMangerScript;
    private Score scoreManagerScript;
    private RoundManager roundManagerScript;

    private AndroidJavaObject mActivity;
    private AndroidJavaObject mIntent;
    private string sAction;

    public SoundPlayer soundplayer;

    public int[] pointPlays;
    public int[] specialPlays;
    List<int> neworderPoint = new List<int>();
    List<int> neworderSpecial = new List<int>();


    //sound logic
    public bool alreadyPlayed = false;
    string result = "";
    string lastResult = "";

    void Start()
    {
        playerMangerScript = playerManager.GetComponent<PlayerManager>();
        scoreManagerScript = scoreManager.GetComponent<Score>();
        roundManagerScript = roundManager.GetComponent<RoundManager>();

        RandomizeSounds(neworderPoint,soundplayer.pointSounds.Length);
        RandomizeSounds(neworderSpecial, soundplayer.specialSounds.Length);
        //tag_output_text.text = "No tag...";
    }

    void Update()
    {
        
        //TestPoints();
        if (Input.GetKeyDown(KeyCode.A))
        {
            soundplayer.PlaySpecialSound(neworderPoint[0]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            soundplayer.PlaySpecialSound(neworderPoint[1]);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            soundplayer.PlaySpecialSound(neworderPoint[2]);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            soundplayer.PlaySpecialSound(neworderPoint[3]);
        }
        //soundplayer.PlaySound(neworderPoint[0]);
        //soundplayer.PlaySound(2);
        //soundplayer.PlaySound(4);
        //soundplayer.PlaySpecialSound(neworderSpecial[1]);
        //soundplayer.PlaySpecialSound(0);

        if (Application.platform == RuntimePlatform.Android)
        {
            ScanNFC();
            if (!tagFound)
            {
                CheckIfResultChanged();
                PlaySounds();
                lastResult = result;

                
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
                //lastResult = result;
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
        if (ScanNFC() != lastResult)
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

    void RandomizeSounds(List<int> neworder, int soundLength)
    {
        List<int> orderer = new List<int>();
        for (int i = 0; i < soundLength; i++)
        {
            orderer.Add(i);
        }

        for (int i = 0; i < soundLength; i++)
        {
            int rand = Random.Range(0, orderer.Count);
            neworder.Add(orderer[rand]);
            orderer.Remove(orderer[rand]);
        }

    }
    void PlaySounds()
    {
        if(result == "PointCard.1" && !alreadyPlayed)
        {
            soundplayer.PlaySound(neworderPoint[0]);
            AddPlaysPoint(0);
            alreadyPlayed = true;        
        }
        if (result == "PointCard.2" && !alreadyPlayed)
        {
            
            soundplayer.PlaySound(neworderPoint[1]);
            alreadyPlayed = true;
            AddPlaysPoint(1);
        }
        if (result == "PointCard.3" && !alreadyPlayed)
        {
            soundplayer.PlaySound(neworderPoint[2]);
            alreadyPlayed = true;
            AddPlaysPoint(2);
        }
        if (result == "PointCard.4" && !alreadyPlayed)
        {
            soundplayer.PlaySound(neworderPoint[3]);
            alreadyPlayed = true;
            AddPlaysPoint(3);
        }

        if (result == "PointCard.5" && !alreadyPlayed)
        {
            soundplayer.PlaySound(neworderPoint[4]);
            alreadyPlayed = true;
            AddPlaysPoint(4);
        }

        if (result == "PointCard.6" && !alreadyPlayed)
        {
            soundplayer.PlaySound(neworderPoint[5]);
            alreadyPlayed = true;
            AddPlaysPoint(5);
        }

        if (result == "SpecialCard.1" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(neworderSpecial[0]);
            alreadyPlayed = true;
            AddPlaysSpecial(0);
        }
        if (result == "SpecialCard.2" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(neworderSpecial[1]);
            alreadyPlayed = true;
            AddPlaysSpecial(1);
        }
        if (result == "SpecialCard.3" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(neworderSpecial[2]);
            alreadyPlayed = true;
            AddPlaysSpecial(2);
        }
        if (result == "SpecialCard.4" && !alreadyPlayed)
        {
            soundplayer.PlaySpecialSound(neworderSpecial[3]);
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
         soundplayer.PlaySpecialSound(neworderSpecial[0]);
    }
}
