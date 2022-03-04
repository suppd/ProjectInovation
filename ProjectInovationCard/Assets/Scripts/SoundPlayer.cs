using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSoundElements
{
    public int ID;
    public AudioClip sound;
    public int timesPlayed;
}
public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] pointSounds;
    public AudioClip[] specialSounds;
    public int[] IDp;
    public AudioClip scatterSound;
    public float[] volumes;
    public List<CardSoundElements> pointCardSoundElements = new List<CardSoundElements>();
    public List<CardSoundElements> specialCardSoundElements = new List<CardSoundElements>();
    //public CardSoundElements newCardSoundElements;
    AudioSource audioSource;
    //public AudioSource audioSourceSpecial;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        // TODO: verify that both arrays have the same length!
    }
    
    private void Awake()
    {
        addToList(pointCardSoundElements, pointSounds);
        addToList(specialCardSoundElements, specialSounds);

      
    }


    void addToList(List<CardSoundElements> cardSoundElements, AudioClip[] audio)
    {
        for (int i = 0; i < audio.Length; i++)
        {
            CardSoundElements newCardSoundElements = new CardSoundElements();
            newCardSoundElements.sound = audio[i];
            newCardSoundElements.ID = i;
            newCardSoundElements.timesPlayed = 0;
            cardSoundElements.Add(newCardSoundElements);
        }
    }

    public void PlaySound(int index)
    {
        
        if (index>=0 && index< pointCardSoundElements.Count  && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(pointCardSoundElements[index].sound,volumes[index]); // may give out of range error!
            pointCardSoundElements[index].timesPlayed++;
            
        }
    }

    public void PlaySpecialSound(int index)
    {
        if (index >= 0 && index < specialCardSoundElements.Count && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(specialCardSoundElements[index].sound, volumes[index]); // may give out of range error!
            specialCardSoundElements[index].timesPlayed++;

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
