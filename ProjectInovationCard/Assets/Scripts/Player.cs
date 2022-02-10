using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Player")]
public class Player : ScriptableObject
{ 
    public int playerId;
    public new string name;
    
    public Sprite artwork;
    public Sprite artworkBackground;
    
    public int gameScore;
    public int roundScore;
}
