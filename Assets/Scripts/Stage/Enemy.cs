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
    public UnityEngine.UI.Slider origin_hpbar;
    public GameObject enemy_info;
    public UnityEngine.UI.Slider hp_bar;

   private void Start()
    {
        make_hpbar();
    }

    private void make_hpbar()
    {
        RectTransform CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector3 UI_camera = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 WorldObject_ScreenPosition = new Vector3(
        (UI_camera.x * CanvasRect.sizeDelta.x), (UI_camera.y * CanvasRect.sizeDelta.y)-100, 0);

        GameObject about_enemy = GameObject.Find("Enemy_Info");

        Debug.Log(WorldObject_ScreenPosition);

        hp_bar = Instantiate(origin_hpbar, WorldObject_ScreenPosition, this.transform.rotation);
        hp_bar.maxValue = max_hp;
        hp_bar.value = hp;
        hp_bar.transform.parent = about_enemy.transform;
        
    }

    private void check_else_enemy_click()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject child in Enemy_List)
        {
            child.GetComponent<Enemy>().clicked = false;
        }
    }

    void check_hp()
    {
        while (hp > 0)
        {
            hp_bar.value = hp;
        }
        return;
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check_hp();
            Destroy(hp_bar);
        }
    }*/

    public void Destroy_hpbar()
    {
        Destroy(hp_bar.gameObject);
    }

    private void Update()
    {
        if (hp > 0)
            hp_bar.value = hp;
    }

    private void OnMouseDown()
    {
        check_else_enemy_click();
        clicked = !clicked;
        enemy_object.SetActive(true);
    }
}
