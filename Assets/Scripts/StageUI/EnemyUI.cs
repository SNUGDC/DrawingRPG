using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {
    public EnemyStatus enemy;
    public Image enemyPortrait;
    public Image enemyElement;
    public Slider enemyHPBar;
    public Slider enemyFieldHPBar;

    public Text enemyInfoText; // 공격력, 방어력

    //About Portrait
    private void MakePortrait()
    {
        enemyPortrait.sprite = enemy.portrait;
    }

    //About Element
    private void EnemyElement()
    {
        if (enemy.element == Element.Water)
            enemyElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[0];
        else if (enemy.element == Element.Wood)
            enemyElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[1];
        else if (enemy.element == Element.Fire)
            enemyElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[2];
        else if (enemy.element == Element.Earth)
            enemyElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[3];
        else
            enemyElement.sprite = (Resources.Load("ElementList") as GameObject).GetComponent<ElementImageList>().Elements[4];
    }

    //About HP
        private void MakeEnemyHPBar()
    {
        //enemyHPBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        enemyHPBar.maxValue = enemy.maxHp;
        enemyHPBar.value = enemy.hp;
    }

    public void ChangedHP()
    {
        enemyHPBar.value = enemy.hp;
    }
    
    //About Attack, Defense
    public void AttackDefenceText()
    {
        enemyInfoText.text = "공격력 : " + enemy.atk + "\n방어력 : " + enemy.def;
    }

    public void SetActiveEnemyUI()
    {
        MakePortrait();
        EnemyElement();
        MakeEnemyHPBar();
        AttackDefenceText();
    }

    private void Update()
    {

    }
}
