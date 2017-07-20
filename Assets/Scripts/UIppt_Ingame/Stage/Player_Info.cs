using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Info : MonoBehaviour {
    
    public Player player;
    public Image player_element;
    public Text player_atk;
    public List<Sprite> player_element_Image;
	// Use this for initialization
    private void this_element()
    {
        if (player.element == Element.Water)
            player_element.sprite = player_element_Image[0];
        else if (player.element == Element.Wood)
            player_element.sprite = player_element_Image[1];
        else if (player.element == Element.Fire)
            player_element.sprite = player_element_Image[2];
        else if (player.element == Element.Earth)
            player_element.sprite = player_element_Image[3];
        else
            player_element.sprite = player_element_Image[4];

        player_atk.text = "공격력 : " + player.atk;
    }

	void Start () {
        this_element();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
