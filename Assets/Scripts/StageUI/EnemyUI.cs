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
    public List<Sprite> Elements = new List<Sprite>();



    //About Portrait
    private void MakePortrait()
    {
        enemyPortrait.sprite = enemy.portrait;
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

    private void EnemyElement()
    {
        if (enemy.element == Element.Water)
            enemyPortrait.sprite = Elements[0];
        else if (enemy.element == Element.Wood)
            enemyPortrait.sprite = Elements[1];
        else if (enemy.element == Element.Fire)
            enemyPortrait.sprite = Elements[2];
        else if (enemy.element == Element.Earth)
            enemyPortrait.sprite = Elements[3];
        else
            enemyPortrait.sprite = Elements[4];
    }

    //About HP
    private void MakeEnemyHPBar()
    {
        enemyHPBar.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        enemyHPBar.maxValue = enemy.maxHp;
        enemyHPBar.value = enemy.hp;
    }
    
    private void MakeEnemyFieldHPBar()
{
        RectTransform CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        Vector3 UI_camera = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 WorldObject_ScreenPosition = new Vector3(
        (UI_camera.x * CanvasRect.sizeDelta.x), (UI_camera.y * CanvasRect.sizeDelta.y) - 100, 0);

        GameObject about_enemy = GameObject.Find("About_enemy");

        Slider originHPBar = (Slider)Resources.Load("Prefabs/EnemyFieldHPBar");
        enemyFieldHPBar = Instantiate(originHPBar, WorldObject_ScreenPosition, this.transform.rotation);
        enemyFieldHPBar.maxValue = enemy.maxHp;
        enemyFieldHPBar.value = enemy.hp;
        enemyFieldHPBar.transform.parent = about_enemy.transform;
    }
    public void ChangedHP()
    {
        enemyHPBar.value = enemy.hp;
    }

    public void ChangeFieldHP()
    {
        enemyFieldHPBar.value = enemy.hp;
        if (enemy.hp <= 0)
        {
            Destroy(enemyFieldHPBar);
        }
    }

    //About Attack, Defense
    public void AttackDefenceText()
    {
        enemyInfoText.text = "공격력 : " + enemy.atk + "\n방어력 : " + enemy.def;
    }

    private void Start()
    {
        MakePortrait();
        MakeElementsList();
        EnemyElement();
        MakeEnemyHPBar();
        MakeEnemyFieldHPBar();
        AttackDefenceText();
    }

    private void Update()
    {
        ChangedHP();
        ChangeFieldHP();
    }
}
