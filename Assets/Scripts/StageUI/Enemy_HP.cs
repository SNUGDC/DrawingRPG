using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HP : MonoBehaviour {

    private bool activeCheck = false;
    private int maxHp;
    private int currentHp;
    
    public Sprite hpLoss;
    public Sprite hpUnit;
    public Image[] enemyHpBar;

    private void make_maxhp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            enemyHpBar[i].sprite = hpUnit;
        }
        for (int i = maxHp; i < 10; i++)
        {
            Destroy(enemyHpBar[i]);
        }
    }

    public void checkHp(Enemy enemy)
    {
        currentHp = enemy.hp;
        for (int i = 0; i < maxHp; i++)
        {
            if (currentHp > i)
                enemyHpBar[i].sprite = hpUnit;
            else
                enemyHpBar[i].sprite = hpLoss;
        }
    }

    public void setEnemy(Enemy enemy)
    {
        maxHp = enemy.maxHp;
        currentHp = enemy.hp;
        make_maxhp();
        checkHp(enemy);
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
