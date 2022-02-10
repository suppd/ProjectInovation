using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScanScript : MonoBehaviour
{
	//public TextMeshProUGUI displayText;
	public Text displayText;

	void Start()
	{
		AndroidNFCReader.enableBackgroundScan();
		AndroidNFCReader.ScanNFC(gameObject.name, "OnFinishScan");
	}

	// NFC callback returns result to use for card game
	void OnFinishScan(string result)
	{
		if (result == AndroidNFCReader.CANCELLED)
		{
			// The user has canceled the scan (back button)
		}
		else if (result == AndroidNFCReader.ERROR)
		{
			// There was an error reading the NFC tag
		}
		else if (result == AndroidNFCReader.NO_HARDWARE)
		{
			// No NFC hardware available
		}
		// result contains the NFC tag text content

		displayText.text = result;
	}

	void Update()
    {
		AndroidNFCReader.ScanNFC(gameObject.name, "OnFinishScan");
	}
	
}
