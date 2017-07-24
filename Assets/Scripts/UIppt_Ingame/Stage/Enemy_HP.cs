using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HP : MonoBehaviour {

    private bool check_active = false;
    private int maxHP;
    private int current_HP;
    
    public Sprite blank_hp;
    public Sprite full_hp;
    public Image[] enemy_hp_bar;

    private void make_maxhp()
    {
        for (int i = 0; i < maxHP; i++)
        {
            enemy_hp_bar[i].sprite = full_hp;
        }
        for (int i = maxHP; i < 10; i++)
        {
            Destroy(enemy_hp_bar[i]);
        }
    }

    public void check_HP(Enemy new_enemy)
    {
        current_HP = new_enemy.hp;
        for (int i = 0; i < maxHP; i++)
        {
            if (current_HP > i)
                enemy_hp_bar[i].sprite = full_hp;
            else
                enemy_hp_bar[i].sprite = blank_hp;
        }
    }

    public void Set_Enemy(Enemy new_enemy)
    {
        maxHP = new_enemy.max_hp;
        current_HP = new_enemy.hp;
        make_maxhp();
        check_HP(new_enemy);
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
