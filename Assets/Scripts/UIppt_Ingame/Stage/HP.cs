using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
    private int maxHP;
    private int current_HP;

    private float duration = 3.0f;
    private bool is_game_over = false;
    public Player player;
    public Sprite blank_hp;
    public Sprite full_hp;
    public GameObject Game_Over_Image;
    public Image[] player_hp_bar;
	// Use this for initialization
	void Start () {
        maxHP = 5;
        current_HP = player.hp;
        check_HP();
	}
    
    
    void Update()
    {
        current_HP = player.hp;
        check_HP();
        if (current_HP <= 0 && is_game_over == false)
        {
            Game_Over_Image.GetComponent<Image>().canvasRenderer.SetAlpha(0);
            Game_Over_Image.SetActive(true);
            Game_Over_Image.GetComponent<Image>().CrossFadeAlpha(1, duration, true);
            is_game_over = true;
        }
            
    }

    void check_HP()
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (current_HP > i)
            {
                player_hp_bar[i].sprite = full_hp;
            }
            else
            {
                player_hp_bar[i].sprite = blank_hp;
            }
        }
    }
}
