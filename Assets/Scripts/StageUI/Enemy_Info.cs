using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Info : MonoBehaviour {
    public Image enemyElement;
    public Image enemyPortrait;
    public Text enemyAtk;
    public List<Sprite> enemyElementImage;

    public Animator animator;
    
    // Use this for initialization
    private void thisElement(Enemy enemy)
    {
        if (enemy.element == Element.Water)
            enemyElement.sprite = enemyElementImage[0];
        else if (enemy.element == Element.Wood)
            enemyElement.sprite = enemyElementImage[1];
        else if (enemy.element == Element.Fire)
            enemyElement.sprite = enemyElementImage[2];
        else if (enemy.element == Element.Earth)
            enemyElement.sprite = enemyElementImage[3];
        else
            enemyElement.sprite = enemyElementImage[4];

        enemyAtk.text = "공격력 : " + enemy.atk;
    }

    public void Active(Enemy enemy)
    {
        enemyPortrait.sprite = enemy.portrait;
        thisElement(enemy);
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    /*void Update()
    {
        if (Active() == true)
        {
            this_element();
            enemy_portrait.sprite = enemy.GetComponent<Sprite>();
            maxHP = enemy.max_hp;
            make_maxhp();
            current_HP = enemy.hp;
            check_HP();
        }
       
    }*/
}
