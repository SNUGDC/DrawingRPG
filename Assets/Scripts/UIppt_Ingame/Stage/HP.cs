using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
    private int maxHP;
    private int current_HP;
    public Player player;
    public Sprite blank_hp;
    public Sprite full_hp;
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
