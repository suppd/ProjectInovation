using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNDisplayPlayers : MonoBehaviour
{
    [SerializeField] private GameObject playerInfoTemplate;
    [SerializeField] private Transform playerInfoContainer;

    [SerializeField] private GameObject playerManger;
    private PlayerManager _playerManager;
    private int _currentlyDisplayed;
    
    private void Awake()
    {
        _playerManager = playerManger.GetComponent<PlayerManager>();
    }

    void Update()
    {
        showBoxes();
    }

    void showBoxes()
    {
        float placementY;
        if (_playerManager._playerElements.Count >= 4)
        {
            placementY = 100;

        }
        else
        {
            placementY = 125;
        }
        if (_currentlyDisplayed < _playerManager._playerElements.Count)
        {

                GameObject templateInstantiate = Instantiate(playerInfoTemplate,playerInfoContainer);
                templateInstantiate.transform.localPosition = new Vector3(-100, -125 * _currentlyDisplayed, 0);
                templateInstantiate.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                Text templateText = templateInstantiate.GetComponentInChildren<Text>();
                templateText.text = _playerManager._playerElements[_currentlyDisplayed].playerName;
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
