﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Player player;
    public Image playerPortrait;
    public Image playerElement;
    public Slider playerHPBar;
    public Text playerInfoText; // 공격력, 방어력

    //About Portrait
    private void MakePortrait()
    {
        playerPortrait.sprite = player.portrait;
    }
    //About Element
    private void PlayerElement()
    {
        if (player.element == Element.Water)
            playerElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[0];
        else if (player.element == Element.Wood)
            playerElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[1];
        else if (player.element == Element.Fire)
            playerElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[2];
        else if (player.element == Element.Earth)
            playerElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[3];
        else
            playerElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[4];
    }

    //About HP
    private void MakePlayerHPBar()
    {
        //playerHPBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        playerHPBar.maxValue = player.maxHp;
        playerHPBar.value = (float)player.hp;
    }

    public void ChangedHP()
    {
        playerHPBar.value = (float)player.hp;
    }

    //About Attack
    public void AttackText()
    {
        playerInfoText.text = "공격력 : " + player.atk;
    }
    
    public static void MakePanel(PlayerUI playerUI, Player player)
    {
        playerUI.player = player;
        playerUI.MakePortrait();
        playerUI.PlayerElement();
        playerUI.MakePlayerHPBar();
        playerUI.AttackText();
    }

    private void Update()
    {
        ChangedHP();
    }
}
