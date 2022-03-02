using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardElements
{
    //public Image cardImage;
    public string CardName;

    public enum CardType
    {
        point,
        power,
        shifter
    }; //point power shifter
    public int ID;
    public int CardPoints;
    public AudioSource CardSound;
}

public class CardSounds
{
    //lists//
    List<AudioSource> pointCardSounds;
    List<AudioSource> specialCardSounds;


    public AudioSource pointCard1;
    public AudioSource pointCard2;
    public AudioSource pointCard3;
    public AudioSource pointCard4;
    public AudioSource pointCard5;
    public AudioSource pointCard6;

    public AudioSource specialCard1;
    public AudioSource specialCard2;
    public AudioSource specialCard3;
    public AudioSource specialCard4;

    public AudioSource strongCard;

    public string SoundName;

    public GameObject pointSound;
    public GameObject specialSound;
    void Start()
    {
        pointCardSounds.Add(pointSound.GetComponent<AudioSource>());
        specialCardSounds.Add(pointSound.GetComponent<AudioSource>());
    }
    public enum CardType
    {
        point,
        power,
        shifter
    };

    void RandomizePointSounds()
    {
        for (int i = 0; i < pointCardSounds.Count; i++)
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

public class CardManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
