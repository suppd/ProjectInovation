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
