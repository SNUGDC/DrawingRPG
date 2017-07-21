using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_clicked : MonoBehaviour {
    public Enemy enemy;
    public Image enemy_element;
    public Image enemy_portrait;
    public Text enemy_atk;
    public List<Sprite> enemy_element_Image;

    public Animator animator;
    
    private bool check_active=false;
    private int maxHP;
    private int current_HP;

    public Sprite blank_hp;
    public Sprite full_hp;
    public Image[] enemy_hp_bar;
    // Use this for initialization
    private void this_element()
    {
        if (enemy.element == Element.Water)
            enemy_element.sprite = enemy_element_Image[0];
        else if (enemy.element == Element.Wood)
            enemy_element.sprite = enemy_element_Image[1];
        else if (enemy.element == Element.Fire)
            enemy_element.sprite = enemy_element_Image[2];
        else if (enemy.element == Element.Earth)
            enemy_element.sprite = enemy_element_Image[3];
        else
            enemy_element.sprite = enemy_element_Image[4];

        enemy_atk.text = "공격력 : " + enemy.atk;
    }
    
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

    public bool Active()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            if (child.GetComponent<Enemy>().clicked == true)
            {
                enemy = child.GetComponent<Enemy>();
                
                return true;
            }
        }
        return false;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
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
       
    }
}
