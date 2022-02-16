using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerInfoTemplate;
    [SerializeField] private Transform playerInfoContainer;

    [SerializeField] private GameObject playerManger;
    private PlayerManager _playerManager;
    private int _currentlyDisplayed;

    [SerializeField] private bool _showScore = false;

    private void Awake()
    {
        _playerManager = playerManger.GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (_showScore == false)
        {
            showBoxes();
        }
        else
        {
            showScores();
        }
    }

    void showBoxes()
    {
        // _currentlyDisplayed = 0;
        // if (_currentlyDisplayed < _playerManager._playerElements.Count)
        // {
        //     GameObject templateInstantiate = Instantiate(playerInfoTemplate, playerInfoContainer);
        //     Text templateText = templateInstantiate.GetComponentInChildren<Text>();
        //     templateText.text = _playerManager._playerElements[_currentlyDisplayed].playerName;
        //     _currentlyDisplayed++;
        // }
        if (_currentlyDisplayed < _playerManager._playerElements.Count)
        {
            // for (int i = 0; i < _playerManager._playerElements.Count; i++)
            // {
                GameObject templateInstantiate = Instantiate(playerInfoTemplate, playerInfoContainer);
                templateInstantiate.transform.localPosition = new Vector3(0, -150 * _currentlyDisplayed, 0);
                Text templateText = templateInstantiate.GetComponentInChildren<Text>();
                templateText.text = _playerManager._playerElements[_currentlyDisplayed].playerName;
            // }
            _currentlyDisplayed = _playerManager._playerElements.Count;
        }
    }

    void showScores()
    {
        _currentlyDisplayed = 0;
        for (int i = 0; i < _playerManager._playerElements.Count; i++)
        {
            GameObject templateInstantiate = Instantiate(playerInfoTemplate, playerInfoContainer);
            Text templateText = templateInstantiate.GetComponentInChildren<Text>();
            templateText.text = _playerManager._playerElements[_currentlyDisplayed].playerName;
            _currentlyDisplayed++;  
        }
    }
}
