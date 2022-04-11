using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class IntroScript : MonoBehaviour
{
    public VideoPlayer vidPlayer;

    public GameObject startGameObject;
    public GameObject logo;
    public GameObject bg;
    public GameObject button;
    void Start()
    {
        
    }

    void Update()
    {
        if (vidPlayer.isPlaying)
        {
            startGameObject.gameObject.SetActive(false);
            logo.gameObject.SetActive(false);
            bg.gameObject.SetActive(false);
            button.gameObject.SetActive(true);
        }
        else
        {            
            startGameObject.gameObject.SetActive(true);
            logo.gameObject.SetActive(true);
            bg.gameObject.SetActive(true);
            button.gameObject.SetActive(false);

        }
    }

    public void StopPlaying()
    {
        
        vidPlayer.Stop();
        //this.gameObject.SetActive(false);
    }
}
