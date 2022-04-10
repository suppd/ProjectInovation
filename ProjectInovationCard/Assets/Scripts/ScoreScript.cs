using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private GameObject normalScores;
    [SerializeField] private GameObject topScore;
    [SerializeField] private Transform playerInfoContainer;
    [SerializeField] private GameObject playerManger;
    [SerializeField] private GameObject roundManager;


    public List<GameObject> inputFields = new List<GameObject>();
    public  Dictionary<string,int> playerD = new Dictionary<string,int>();

    private RoundManager _roundManager;
    private PlayerManager _playerManager;
    private int _currentlyDisplayed;

    private void Awake()
    {
        _roundManager = roundManager.GetComponent<RoundManager>();
        _playerManager = playerManger.GetComponent<PlayerManager>();
        
        showBoxes();
    }



    void showBoxes()
    {

        GameObject topscoreIniate = Instantiate(topScore, playerInfoContainer);
        topscoreIniate.transform.localPosition = new Vector3(-100, 0, 0);
        Text topText = topscoreIniate.GetComponentInChildren<Text>();
        topText.text = _playerManager._playerElements[0].playerName;
        for (int i = 1; i < _playerManager._playerElements.Count; i++)
        {
            GameObject templateInstantiate = Instantiate(normalScores, playerInfoContainer);
            templateInstantiate.transform.localPosition = new Vector3(-100, -125 * i, 0);
            templateInstantiate.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            Text templateText = templateInstantiate.GetComponentInChildren<Text>();
            templateText.text = _playerManager._playerElements[i].playerName;
            //_currentlyDisplayed = _playerManager._playerElements.Count;
        }

    }

    void Update()
    {
       
    }
}
