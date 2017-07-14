using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn_Count : MonoBehaviour
{
    public Player player;
    public int Limit_turn;
    public GameObject Game_Over_Image;
    public GameObject black;
    public GameObject again;
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
            black.GetComponent<Image>().canvasRenderer.SetAlpha(0);
            black.SetActive(true);
            black.GetComponent<Image>().CrossFadeAlpha(1, 1.0f, true);
            Game_Over_Image.GetComponent<Image>().canvasRenderer.SetAlpha(0);
            Game_Over_Image.SetActive(true);
            Game_Over_Image.GetComponent<Image>().CrossFadeAlpha(1, duration, true);
            turn_over = true;
        }
        if (turn_over == true)
            again.SetActive(true);
        text.text = "Turn " + player.move_count + "/" + Limit_turn;
    }
}
