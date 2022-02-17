using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public enum GameState
    {
        StartScreen,
        AddPlayers,
        Rounds, // more specifics
        Calculate
    }
}
