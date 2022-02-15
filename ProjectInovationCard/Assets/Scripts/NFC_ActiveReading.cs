using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using distriqt.plugins.nfc;
using UnityEngine.UI;

public class NFC_ActiveReading : MonoBehaviour
{
    public Text displayText;
    void Start()
    {
        NFC.Instance.EnableReaderMode();
        SetupNFCScanner();
    }

    void Update()
    {
        NFC.Instance.OnNdefDiscovered += Instance_OnNdefDiscovered;
    }

    void Instance_OnNdefDiscovered(NFCEvent e)
    {
        // ndef tag detected
        if (NFC.isSupported)
        {
            //Debug.Log("Working on android!!");
            displayText.text = "Nfc tag scanned now processing data to see what to do...";
            //displayText.text = e.tag.messages[0].records[0].id;
            //for (int i = 0; i < e.tag.messages[i].records.Count; i++)
            //{
            //    displayText.text = e.tag.messages[0].records[0].payload;
            //}
        }
    }

    void SetupNFCScanner()
    {
        //ScanOptions options = new ScanOptions();
        //options.urls = new string[] { "This is a power card" };
        //NFC.Instance.RegisterForegroundDispatch(options);
    }
}