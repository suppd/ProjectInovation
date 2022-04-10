using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerElements
{
        public Image chaImage;
        public Image backImage;
        public string playerName;
        public int iD;
        public int score;
        public int roundScore;
        public int gameScore;
}

public class PlayerManager : MonoBehaviour
{
        public List<PlayerElements> _playerElements = new List<PlayerElements>();

        private void Update()
        {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                        Debug.Log(_playerElements.Count);
                        DebugShowPlayerNames();
                }
        }

        void DebugShowPlayerNames()
        {
                for (int i = 0; i < _playerElements.Count; i++)
                {
                        Debug.Log(_playerElements[i].playerName);
                }
        }

        public void AddPlayer(InputField inputName)
        {
                PlayerElements newPlayer = new PlayerElements();
                newPlayer.playerName = inputName.text;
                newPlayer.iD = _playerElements.Count + 1;
                newPlayer.score = 0;
                _playerElements.Add(newPlayer);
        }
}

