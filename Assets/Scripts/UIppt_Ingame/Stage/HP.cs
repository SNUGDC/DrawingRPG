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
    public GameObject next;
    // Use this for initialization
    private void make_max_hp()
    {
        for (int i = 0; i < maxHP; i++)
        {
            player_hp_bar[i].sprite = full_hp;
        }
        for (int i = maxHP; i < 5; i++)
        {
            Destroy(player_hp_bar[i]);
        }
    }

    void Start () {
        maxHP = player.max_hp;
        current_HP = player.hp;
        make_max_hp();
	}
    
    public static void check_hp(HP hp_bar, Player player)
    {
        hp_bar.current_HP = player.hp;
        hp_bar.check_HP(player);
        if (hp_bar.current_HP <= 0 && player.is_clear == false)
        {
            GameClear.game_Over(player);
        }
    }
    

    void check_HP(Player player)
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
