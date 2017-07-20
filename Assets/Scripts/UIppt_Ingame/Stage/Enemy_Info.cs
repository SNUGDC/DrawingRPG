using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Info : MonoBehaviour {
    public Image enemy_element;
    public Image enemy_portrait;
    public Text enemy_atk;
    public List<Sprite> enemy_element_Image;
    // Use this for initialization
    private void this_element()
    {
        if (this.GetComponent<Enemy>().element == Element.Water)
            enemy_element.sprite = enemy_element_Image[0];
        else if (this.GetComponent<Enemy>().element == Element.Wood)
            enemy_element.sprite = enemy_element_Image[1];
        else if (this.GetComponent<Enemy>().element == Element.Fire)
            enemy_element.sprite = enemy_element_Image[2];
        else if (this.GetComponent<Enemy>().element == Element.Earth)
            enemy_element.sprite = enemy_element_Image[3];
        else
            enemy_element.sprite = enemy_element_Image[4];

        enemy_atk.text = "공격력 : " + this.GetComponent<Enemy>().atk;
    }
    
    void Start()
    {
        enemy_portrait.sprite = this.GetComponent<Sprite>();
        this_element();
    }
    
}
