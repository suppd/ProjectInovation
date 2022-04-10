using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject playerManger;
    [SerializeField] private GameObject roundManager;

    public Dictionary<string, int> playerD = new Dictionary<string, int>();

    private RoundManager _roundManager;
    private PlayerManager _playerManager;

    private void Start()
    {
        _roundManager = roundManager.GetComponent<RoundManager>();
        _playerManager = playerManger.GetComponent<PlayerManager>();
    }

    public void AddScore(int id, int score)
    {
        if (id == _roundManager.currentPlayerID)
        {
            _playerManager._playerElements[id - 1].score += score;
        }
    }


    void Update()
    {

    }
}
