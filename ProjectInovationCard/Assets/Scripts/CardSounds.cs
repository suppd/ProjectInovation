using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSoundElements
{
    public int ID;
    public AudioSource sound;
}

public class CardSounds : MonoBehaviour
{
    //lists/

    public List<CardSoundElements> pointCardSoundElements = new List<CardSoundElements>();
    public List<CardSoundElements> specialCardSoundElements = new List<CardSoundElements>();

    public AudioSource strongCard;

    public string SoundName;

    public GameObject pointSound;
    public GameObject specialSound;
    CardSoundElements newPointCardSoundElement = new CardSoundElements();
    CardSoundElements newSpecialCardSoundElement = new CardSoundElements();

    void Start()
    {
        
        newPointCardSoundElement.sound = pointSound.GetComponent<AudioSource>();
        newPointCardSoundElement.ID = pointCardSoundElements.Count;
        pointCardSoundElements.Add(newPointCardSoundElement);

        
        newSpecialCardSoundElement.sound = specialSound.GetComponent<AudioSource>();
        newSpecialCardSoundElement.ID = specialCardSoundElements.Count;
        specialCardSoundElements.Add(newSpecialCardSoundElement);

    }
    public enum CardType
    {
        point,
        power,
        shifter
    };

    void RandomizePointSounds()
    {
        for (int i = 0; i < .Count; i++)
        {
            AudioSource temp = pointCardSounds[i];
            int randomIndex = Random.Range(i, pointCardSounds.Count);
            pointCardSounds[i] = pointCardSounds[randomIndex];
            pointCardSounds[randomIndex] = temp;
        }
    }

    void RandomizeSpecialCards()
    {
        for (int i = 0; i < specialCardSounds.Count; i++)
        {
            AudioSource temp = specialCardSounds[i];
            int randomIndex = Random.Range(i, specialCardSounds.Count);
            specialCardSounds[i] = specialCardSounds[randomIndex];
            specialCardSounds[randomIndex] = temp;
        }
    }

}
