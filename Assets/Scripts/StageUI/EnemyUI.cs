using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {
    public Enemy enemy;
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

    public static void MakeEnemyFieldHPBar(Enemy enemy, GameObject aboutEnemy)
{
        RectTransform CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector3 UI_camera = Camera.main.WorldToViewportPoint(enemy.transform.position);

        Vector3 WorldObject_ScreenPosition = new Vector3(
        (UI_camera.x * CanvasRect.sizeDelta.x), (UI_camera.y * CanvasRect.sizeDelta.y) - 100, 0);
        

        enemy.enemyFieldHPBar = Instantiate(Resources.Load("EnemyFieldHPBar") as GameObject, WorldObject_ScreenPosition, enemy.transform.rotation);
        
        enemy.enemyFieldHPBar.GetComponent<Slider>().maxValue = enemy.maxHp;
        enemy.enemyFieldHPBar.GetComponent<Slider>().value = enemy.hp;
        enemy.enemyFieldHPBar.transform.parent = aboutEnemy.transform;
    }

    public static void ChangedFieldHPBar(Enemy enemy)
    {
        enemy.enemyFieldHPBar.GetComponent<Slider>().value = enemy.hp;
    }
    

    //About Attack, Defense
    public void AttackDefenceText()
    {
        enemyInfoText.text = "공격력 : " + enemy.atk + "\n방어력 : " + enemy.def;
    }

    /*private void Start()
    {
        MakePortrait();
        EnemyElement();
        MakeEnemyHPBar();
        AttackDefenceText();
    }*/

    public void SetActiveEnemyUI()
    {
        MakePortrait();
        EnemyElement();
        MakeEnemyHPBar();
        AttackDefenceText();
    }
    
    private void Update()
    {
        if (enemy != null)
        {
            ChangedHP();
        }
    }
}
