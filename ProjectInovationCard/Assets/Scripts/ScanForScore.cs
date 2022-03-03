using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanForScore : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;


    void Scan(CardElements cardForScore)
    {
        _playerManager._playerElements[1].gameScore += cardForScore.CardPoints;
    }
}
