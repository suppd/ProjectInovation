using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    public int round;
    public int[] turn;
    
    [SerializeField] private PlayerManager _playerManager;
    private List<PlayerElements> _newOrder = new List<PlayerElements>();
    private List<int> _orderer = new List<int>();

    void Reorder()
    {
        ///<Summary>
        /// have a int list with the same lenght as the player list<order>
        /// a dublicate player list <roundOrder>
        /// we get a random nunber form <order>
        /// we add that corespodding player form <original> to the newxt space in <roundOrder>
        /// and we remove the number form list <order> the next time we do the same with the rest of the elements in order ///

        for (int  i = 0;  i < _playerManager._playerElements.Count;  i++)
        {
            _orderer.Add(i);
        }
        Debug.Log("orderer========================");
        for (int i = 0; i < _orderer.Count; i++)
        {
            Debug.Log(_orderer[i].ToString());
        }
        Debug.Log("orderer========================");

        for (int i = 0; i < _playerManager._playerElements.Count; i++)
        {
                int rand = Random.Range(0, _orderer.Count);
                Debug.Log("we remove the" + rand + "element whitch is" + _orderer[rand]);
                _newOrder.Add(_playerManager._playerElements[_orderer[rand]]);
                _orderer.Remove(_orderer[rand]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Reorder();
            DebugShowPlayerNames();
        }
    }
    
    void DebugShowPlayerNames()
    {
        Debug.Log("****aide****");
        for (int i = 0; i < _newOrder.Count; i++)
        {
            Debug.Log(_newOrder[i].playerName);
        }
        _newOrder.Clear();//for testing purpases
    }

    void Turn()
    {
        switch (turn.Length)
        {
            default:
                print ("None");
                break;
        }
    }
    void Rounds()
    {
        switch (round)
        {
            default:
                print ("None");
                break;
            case 1:
                print ("InRoundOne");
                break;
            case 2:
                print ("EndRoundOne");
                print ("InRoundTwo");
                break;
            case 3:
                print ("EndRoundTwo");
                print ("InRoundThree");
                break;
            case 4:
                print ("EndRoundThre");
                print ("InRoundFour");
                break;
            case 5:
                print ("EndRoundFour");
                print ("InRoundFive");
                break;
        }
    }
}
