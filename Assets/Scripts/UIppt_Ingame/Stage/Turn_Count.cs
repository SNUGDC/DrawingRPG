using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Count : MonoBehaviour{
    public Player player;
    public int Limit_turn;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = "Turn " + player.move_count + "/" + Limit_turn;
    }
}
