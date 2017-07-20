using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int max_hp;
    public int atk;
    public int hp;
    public bool clicked = false;
    //public string element;
    public Element element;
    public GameObject enemy_object;
    

    private void check_else_enemy_click()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            child.GetComponent<Enemy>().clicked = false;
        }
    }

    private void OnMouseDown()
    {
        check_else_enemy_click();
        clicked = !clicked;
        enemy_object.SetActive(true);
    }
}
