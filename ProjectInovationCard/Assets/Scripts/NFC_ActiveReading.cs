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
            Debug.Log("Working on android!!");
            displayText.text = "it works";
        }
    }
}