using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndicator : MonoBehaviour
{
    public NFC_Reader nfcReader;
    public SoundPlayer soundPlayer;

    public int[] pointPlays;
    public int[] specialPlays;

    //public GameObject[] sections;

    public GameObject[] blist1;
    public GameObject[] blist2;
    public GameObject[] blist3;
    public GameObject[] blist4;
    public GameObject[] blist5;
    public GameObject[] blist6;


    public GameObject[] sblist1;
    public GameObject[] sblist2;
    public GameObject[] sblist3;
    public GameObject[] sblist4;


    //public GameObject[][] blocks = new GameObject[][] { blist1, blist2, blist3, blist4, blist5, blist6 };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < soundPlayer.pointCardSoundElements.Count; i++)
        {
            if(soundPlayer.pointCardSoundElements[i].timesPlayed >=1)
            {
                for (int j = 0; j <soundPlayer.pointCardSoundElements[i].timesPlayed; j++)
                {
                    if (i == 0)
                    {
                        blist1[j].SetActive(true);
                    }
                    else if (i == 1)
                    {
                        blist2[j].SetActive(true);
                    }
                    else if (i == 2)
                    {
                        blist3[j].SetActive(true);
                    }
                    else if (i == 3)
                    {
                        blist4[j].SetActive(true);
                    }
                    else if (i == 4)
                    {
                        blist5[j].SetActive(true);
                    }
                    else if (i == 5)
                    {
                        blist6[j].SetActive(true);
                    }

                }
                
            }
        }

        for (int i = 0; i < soundPlayer.specialCardSoundElements.Count; i++)
        {
            if (soundPlayer.specialCardSoundElements[i].timesPlayed >= 1)
            {
                for (int j = 0; j < soundPlayer.specialCardSoundElements[i].timesPlayed; j++)
                {
                    if (i == 0)
                    {
                        sblist1[j].SetActive(true);
                    }
                    else if (i == 1)
                    {
                        sblist2[j].SetActive(true);
                    }
                    else if (i == 2)
                    {
                        sblist3[j].SetActive(true);
                    }
                    else if (i == 3)
                    {
                        sblist4[j].SetActive(true);
                    }

                }

            }
        }

    }



}
