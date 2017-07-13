using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Count : MonoBehaviour{
    public Player player;
    public int Limit_turn;
    public GameObject Game_Over_Image;
    private float duration = 3.0f;
    private bool turn_over = false;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        
        if (player.move_count>Limit_turn && turn_over == false)
        {
            turn_over = true;
            Game_Over_Image.GetComponent<Image>().canvasRenderer.SetAlpha(0);
            Game_Over_Image.SetActive(true);
            Game_Over_Image.GetComponent<Image>().CrossFadeAlpha(1, duration, true);
            turn_over = true;
        }
        text.text = "Turn " + player.move_count + "/" + Limit_turn;
    }
}
