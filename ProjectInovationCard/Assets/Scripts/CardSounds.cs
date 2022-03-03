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
    public List<AudioSource[]> sounds;

    public AudioSource strongCard;

    public string SoundName;

    public GameObject pointSound;
    public GameObject specialSound;
    CardSoundElements newPointCardSoundElement = new CardSoundElements();
    CardSoundElements newSpecialCardSoundElement = new CardSoundElements();

    void Start()
    {
        GettingComponents(pointSound, pointCardSoundElements, newPointCardSoundElement);
        GettingComponents(specialSound, specialCardSoundElements, newSpecialCardSoundElement);

        //newPointCardSoundElement.sound = pointSound.GetComponent<AudioSource>();
        //newPointCardSoundElement.ID = pointCardSoundElements.Count;
        //pointCardSoundElements.Add(newPointCardSoundElement);

        
        //newSpecialCardSoundElement.sound = specialSound.GetComponent<AudioSource>();
        //newSpecialCardSoundElement.ID = specialCardSoundElements.Count;
        //specialCardSoundElements.Add(newSpecialCardSoundElement);

    }
    public enum CardType
    {
        point,
        power,
        shifter
    };

    void GettingComponents(GameObject soundHolder, List<CardSoundElements> cardSoundElements, CardSoundElements newCardSoundElement)
    {
        Component[] components = soundHolder.GetComponents<AudioSource>();
        for (int i= 0; i < components.Length; i++)
        {
            newCardSoundElement.sound = components[i].GetComponent<AudioSource>();
            newCardSoundElement.ID = i;
            cardSoundElements.Add(newCardSoundElement);
            //Debug.Log(components.ToString());
            Debug.Log(components[i].name);
        }
        Debug.Log(cardSoundElements[3].sound.clip.name);
        //Debug.Log(components.Length);
    }

    void RandomizePointSounds()
    {
        for (int i = 0; i < pointCardSoundElements.Count; i++)
        {
            CardSoundElements temp = pointCardSoundElements[i];
            int randomIndex = Random.Range(i, pointCardSoundElements.Count);
            pointCardSoundElements[i] = pointCardSoundElements[randomIndex];
            pointCardSoundElements[randomIndex] = temp;
        }
    }

    void RandomizeSpecialCards()
    {
        for (int i = 0; i < specialCardSoundElements.Count; i++)
        {
            CardSoundElements temp = specialCardSoundElements[i];
            int randomIndex = Random.Range(i, specialCardSoundElements.Count);
            specialCardSoundElements[i] = specialCardSoundElements[randomIndex];
            specialCardSoundElements[randomIndex] = temp;
        }
    }

}
