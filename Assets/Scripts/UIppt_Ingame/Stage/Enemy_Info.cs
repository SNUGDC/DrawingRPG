using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Info : MonoBehaviour {
    public Image enemy_Element;
    public Image enemy_Portrait;
    public Text enemy_Atk;
    public List<Sprite> enemy_Element_Image;

    public Animator animator;
    
    // Use this for initialization
    private void this_Element(Enemy enemy)
    {
        if (enemy.element == Element.Water)
            enemy_Element.sprite = enemy_Element_Image[0];
        else if (enemy.element == Element.Wood)
            enemy_Element.sprite = enemy_Element_Image[1];
        else if (enemy.element == Element.Fire)
            enemy_Element.sprite = enemy_Element_Image[2];
        else if (enemy.element == Element.Earth)
            enemy_Element.sprite = enemy_Element_Image[3];
        else
            enemy_Element.sprite = enemy_Element_Image[4];

        enemy_Atk.text = "공격력 : " + enemy.atk;
    }
    
    public void Active(Enemy new_enemy)
    {
        enemy_Portrait.sprite = new_enemy.portrait;
        this_Element(new_enemy);
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
