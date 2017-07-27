using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public int atk;
    public int def;
    public int hp;
    public int speed;
    public bool clicked = false;
    //public string element;
    public Element element;
    
    public Sprite portrait;
    
    
    

    private void CheckElseEnemyClick()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            child.GetComponent<Enemy>().clicked = false;
        }
    }
    

    public bool DeadCheck()
    {
        if (hp <= 0)
            return true;
        else return false;
    }

   /* public void Active()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            if (child.GetComponent<Enemy>().clicked == true)
            {
                enemy = child.GetComponent<Enemy>();
                this_Element();
                enemy_Portrait.sprite = enemy.GetComponent<Sprite>();
            }
        }
    }*/
    private void OnMouseDown()
    {
        //check_else_enemy_click();
        //clicked = !clicked;
        GameObject.Find("EnemyDetailInfo").SetActive(true);
        GameObject.Find("EnemyDetailInfo").GetComponent<EnemyUI>().enemy = this; 
    }
}
