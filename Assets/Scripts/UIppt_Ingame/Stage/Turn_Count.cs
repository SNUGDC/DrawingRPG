using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Count : Player_stop {
    private int Turn_count;

    Text text;

    void Start()
    {
        Turn_count = 0;
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = "Line " + Turn_count + "/" + Limit_turn;
    }
}
