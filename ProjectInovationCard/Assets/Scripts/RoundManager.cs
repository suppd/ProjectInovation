using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    private int round;
    public int roundsPerGame = 5; 
    private int turn;
    private int turnsPerRound;

    public bool gameOver = false;

    [SerializeField] private PlayerManager _playerManager;
    private List<PlayerElements> _newOrder = new List<PlayerElements>();
    private List<int> _orderer = new List<int>();
    
    [SerializeField] private GameObject _currentAndNext;
    [SerializeField] private GameObject _current;

    [SerializeField] private GameObject[] _highlight;

    public void Reorder()
    {
        Debug.Log("reorderd");
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

        for (int i = 0; i < _playerManager._playerElements.Count; i++)
        {
                int rand = Random.Range(0, _orderer.Count);
                _newOrder.Add(_playerManager._playerElements[_orderer[rand]]);
                _orderer.Remove(_orderer[rand]);
        }

        turnsPerRound = _newOrder.Count;
        turn = 0;
        Turn();
    }

    private void Update()
    {
        Debug.Log("round " + round);
        Debug.Log("turn " + turn);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Reorder();
            DebugShowPlayerNames();
        }

        if (round > roundsPerGame)
        {
            gameOver = true;
        }
    }
    
    void DebugShowPlayerNames()
    {
        Debug.Log("****aide****");
        for (int i = 0; i < _newOrder.Count; i++)
        {
            Debug.Log(_newOrder[i].playerName);
        }
    }
    public void SetupGame()
    {
        round = 1;
        ShowRoundsOnIndicators();
        Reorder();
    }
    public void Turn()
    {
        turn++;
        if (turn > turnsPerRound)
        {
            _newOrder.Clear();
            round++;
            ShowRoundsOnIndicators();
            Reorder();
            Debug.Log("we are in round" + round);
        }
        
        if (turn != turnsPerRound)
        {
            var currentPlayerNames = _currentAndNext.GetComponentInChildren<Text>();
            currentPlayerNames.text = _newOrder[turn -1].playerName + "'s Turn" + Environment.NewLine + "Next" + Environment.NewLine + _newOrder[turn].playerName;
        }
        else
        {
            var currentPlayerNames = _currentAndNext.GetComponentInChildren<Text>();
            currentPlayerNames.text = _newOrder[turn-1].playerName + "'s Turn" + Environment.NewLine;
        }
    }

    public void ShowRoundsOnIndicators()
    {
        _highlight[round-1].SetActive(true);
        if (round != 1)
        {
            _highlight[round - 2].SetActive(false);
        }
    }
}
