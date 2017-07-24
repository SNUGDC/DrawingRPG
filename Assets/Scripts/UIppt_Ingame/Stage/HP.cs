using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
    private int maxHP;
    private int currentHp;
    
    public Player player;
    public Sprite hpLoss;
    public Sprite hpUnit;
    public Image[] playerHpBar;
    public GameObject next;
    // Use this for initialization
    private void SetMaxHp()
    {
        for (int i = 0; i < maxHP; i++)
        {
            playerHpBar[i].sprite = hpUnit;
        }
        for (int i = maxHP; i < 5; i++)
        {
            Destroy(playerHpBar[i]);
        }
    }

    void Start () {
        maxHP = player.maxHp;
        currentHp = player.hp;
        SetMaxHp();
	}
    
    public static void CheckHp(HP hpBar, Player player)
    {
        hpBar.currentHp = player.hp;
        hpBar.CheckHP(player);
        if (hpBar.currentHp <= 0 && player.isClear == false)
        {
            GameClear.GameOver(player);
        }
    }
    

    void CheckHP(Player player)
    {
        for (int i = 0; i < maxHP; i++)
        {
            if (currentHp > i)
            {
                playerHpBar[i].sprite = hpUnit;
            }
            else
            {
                playerHpBar[i].sprite = hpLoss;
            }
        }
    }
}
