using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_hp : MonoBehaviour {
    private int maxHP;
    private int current_HP;
    
    public Sprite blank_hp;
    public Sprite full_hp;
    public Image[] enemy_hp_bar;
    // Use this for initialization
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

    void Start()
    {
        maxHP = this.GetComponent<Enemy>().max_hp ;
        make_maxhp();
    }

    void Update()
    {
        current_HP = this.GetComponent<Enemy>().hp;
        check_HP();
    }

    void check_HP()
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (current_HP > i)
                enemy_hp_bar[i].sprite = full_hp;
            else
                enemy_hp_bar[i].sprite = blank_hp;
        }
    }
}
