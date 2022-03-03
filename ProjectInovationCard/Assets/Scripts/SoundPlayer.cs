using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] pointSounds;
    public AudioClip[] specialSounds;
    public AudioClip scatterSound;
    public float[] volumes;

    AudioSource audioSource;
    //public AudioSource audioSourceSpecial;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // TODO: verify that both arrays have the same length!
    }

    public void PlaySound(int index)
    {
        if (index>=0 && index<pointSounds.Length  && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(pointSounds[index],volumes[index]); // may give out of range error!
        }
    }

    public void PlaySpecialSound(int index)
    {
        if (index >= 0 && index < pointSounds.Length && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(specialSounds[index], volumes[index]); // may give out of range error!
        }
    }

    public void PlayScatterSound()
    {
        audioSource.PlayOneShot(scatterSound);
    }

    // Update is called once per frame
    void Update()
    {
        //// just for debugging:
        //for (int i=0;i<sounds.Length;i++)
        //{
        //    if (Input.GetKeyDown((KeyCode)(i+48))) // hacky!
        //    {
        //        PlaySound(i);
        //    }
        //}
    }
}
