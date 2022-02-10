using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayer : MonoBehaviour
{
    public Player player;
    
    public Text nameText;
    public Text id;
    
    public Image avatar;
    public Image background;

    public Text gameScore;
    public Text roundScore;

    void Start()
    {
        nameText.text = player.name;
        id.text = player.playerId.ToString();

        avatar.sprite = player.artwork;
        background.sprite = player.artworkBackground;

        gameScore.text = player.gameScore.ToString();
        roundScore.text = player.roundScore.ToString();
    }
}
