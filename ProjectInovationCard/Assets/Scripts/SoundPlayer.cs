using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds;
    public float[] volumes;
    public int[] Id;
    public int[] playedNumTimes;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // TODO: verify that both arrays have the same length!
    }

    public void PlaySound(int index)
    {
        if (index>=0 && index<sounds.Length)
        {
            audioSource.PlayOneShot(sounds[index],volumes[index]); // may give out of range error!
        }
    }

    // Update is called once per frame
    void Update()
    {
        // just for debugging:
        for (int i=0;i<sounds.Length;i++)
        {
            if (Input.GetKeyDown((KeyCode)(i+48))) // hacky!
            {
                PlaySound(i);
            }
        }
    }
}
