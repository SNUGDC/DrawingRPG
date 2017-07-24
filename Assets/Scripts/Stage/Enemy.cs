using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public int atk;
    public int hp;
    public int speed;
    public bool clicked = false;
    //public string element;
    public Element element;
    public UnityEngine.UI.Slider origin_hpbar;
    public GameObject Enemy_Information;
    public Sprite portrait;

    private UnityEngine.UI.Slider hp_bar;

    
    private void Start()
    {
        CreatHpbar();
    }

    private void CreatHpbar()
    {
        RectTransform CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector3 UI_camera = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 WorldObject_ScreenPosition = new Vector3(
        (UI_camera.x * CanvasRect.sizeDelta.x), (UI_camera.y * CanvasRect.sizeDelta.y)-100, 0);

        GameObject about_enemy = GameObject.Find("About_enemy");

        hp_bar = Instantiate(origin_hpbar, WorldObject_ScreenPosition, this.transform.rotation);
        hp_bar.maxValue = maxHp;
        hp_bar.value = hp;
        hp_bar.transform.parent = about_enemy.transform;
        
    }

    private void CheckElseEnemyClick()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            child.GetComponent<Enemy>().clicked = false;
        }
    }

    public void CheckHp()
    {
        hp_bar.value = hp;
    }

    public void DestroyHpbar()
    {
        Destroy(hp_bar.gameObject);
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
        Enemy_Information.SetActive(true);
        Enemy_Information.GetComponent<Enemy_HP>().setEnemy(this);
        Enemy_Information.GetComponent<Enemy_Info>().Active(this);
        

    }
}
