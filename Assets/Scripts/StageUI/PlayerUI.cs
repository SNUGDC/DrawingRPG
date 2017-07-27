using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Player player;
    public Image playerPortrait;
    public Image playerElement;
    public Slider playerHPBar;
    public Text playerInfoText; // 공격력, 방어력
    public List<Sprite> Elements = new List<Sprite>();

    //About Portrait
    private void MakePortrait()
    {
        playerPortrait.sprite = player.portrait;
    }
    //About Element
    private void MakeElementsList()
    {
        Elements.Add(Resources.Load("ElementImage/Water") as Sprite);
        Elements.Add(Resources.Load("ElementImage/Wood") as Sprite);
        Elements.Add(Resources.Load("ElementImage/Fire") as Sprite);
        Elements.Add(Resources.Load("ElementImage/Earth") as Sprite);
        Elements.Add(Resources.Load("ElementImage/Metal") as Sprite);
    }

    private void PlayerElement()
    {
        if (player.element == Element.Water)
            playerPortrait.sprite = Elements[0];
        else if (player.element == Element.Wood)
            playerPortrait.sprite = Elements[1];
        else if (player.element == Element.Fire)
            playerPortrait.sprite = Elements[2];
        else if (player.element == Element.Earth)
            playerPortrait.sprite = Elements[3];
        else
            playerPortrait.sprite = Elements[4];
    }

    //About HP
    private void MakePlayerHPBar()
    {
        playerHPBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        playerHPBar.maxValue = player.maxHp;
        playerHPBar.value = player.hp;
    }

    public void ChangedHP()
    {
        playerHPBar.value = player.hp;
    }

    //About Attack, Defense
    public void AttackDefenceText()
    {
        playerInfoText.text = "공격력 : " + player.atk + "\n방어력 : " + player.def;
    }
    
    private void Start()
    {
        MakePortrait();
        MakeElementsList();
        PlayerElement();
        MakePlayerHPBar();
        AttackDefenceText();
    }

    private void Update()
    {
        ChangedHP();
    }
}
