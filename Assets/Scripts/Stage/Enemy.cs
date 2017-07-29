using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite portrait;
    public int maxHp;
    public int atk;
    public int def;
    public int hp;
    public int speed;
    public bool clicked = false;
    
    public Element element;
    
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
    
    private void OnMouseDown()
    {
        clicked = true;
    }
}
