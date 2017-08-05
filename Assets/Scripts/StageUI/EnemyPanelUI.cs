﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyPanelUI : MonoBehaviour {

    public struct EnemyFieldHP {
        public Enemy enemy;
        public Slider enemyFieldHPBar;
    }
    
    public List<EnemyFieldHP> allEnemies = new List<EnemyFieldHP>();
    
    [FormerlySerializedAs("enemyFieldHPBar")]
    public GameObject enemyFieldHPBarPrefab;

    public EnemyUI enemyUIGameObject;

    private void Start()
    {
        enemyUIGameObject.gameObject.SetActive(false);
        MakeEnemyFieldHPBar();
    }

    public void MakeEnemyFieldHPBar()
    {
        GameObject[] Enemy_List = GameObject.FindGameObjectsWithTag("enemy");
        RectTransform CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();

        foreach (GameObject enemy in Enemy_List)
        {
            Vector3 UI_camera = Camera.main.WorldToViewportPoint(enemy.transform.position);

            Vector3 WorldObject_ScreenPosition = new Vector3(
            (UI_camera.x * CanvasRect.sizeDelta.x), (UI_camera.y * CanvasRect.sizeDelta.y) - 100, 0);
            GameObject instantiateHPBar =
            Instantiate(enemyFieldHPBarPrefab, WorldObject_ScreenPosition, enemy.transform.rotation);

            instantiateHPBar.transform.parent = this.transform;
            instantiateHPBar.GetComponent<Slider>().maxValue = enemy.GetComponent<Enemy>().maxHp;
            instantiateHPBar.GetComponent<Slider>().value = enemy.GetComponent<Enemy>().hp;
            EnemyFieldHP newOne = new EnemyFieldHP();
            newOne.enemy = enemy.GetComponent<Enemy>();
            newOne.enemyFieldHPBar = instantiateHPBar.GetComponent<Slider>();
            allEnemies.Add(newOne);
        }
    }
    private void Update()
    {
        foreach (EnemyFieldHP enemyfield in allEnemies)
        {
            enemyfield.enemyFieldHPBar.value = enemyfield.enemy.hp;
            if (enemyfield.enemy.clicked == true)
            {
                enemyfield.enemy.clicked = false;
                enemyUIGameObject.gameObject.SetActive(true);
                enemyUIGameObject.enemy = enemyfield.enemy;
                enemyUIGameObject.SetActiveEnemyUI();
            }
        }
    }
}
