﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject LineDrawrPrefab;
    public List<Vector2> PlayerGoalPosition = new List<Vector2>();
    public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();
    public GameObject goalPoint;
    public List<GameObject> passedLines = new List<GameObject>();
    //public GameObject goal_Image;
    //public GameObject black;
    //public GameObject next;
    //private float duration = 3.0f;

    public HP hpBar;

    public GameObject Black;
    public GameObject Clear;
    public GameObject Fail;
    public GameObject NextStage;
    public GameObject AgainStage;
    public GameObject MoveBattlePanel;

    public int atk;
    public int maxHp;
    public int hp;
    public int speed;
    public int moveCount;

    public bool isClear=false;
    public Element element;
    public bool checkCollideWithGoal;

    public Animator enemyInfoAnimation;

    public LineDrawer LineDrawer;

    private void Awake()
    {
        LineDrawer = Instantiate(LineDrawrPrefab, transform).GetComponent<LineDrawer>();
        LineDrawer.Player = this.gameObject;
    }

    private void Start()
    {
        moveCount = 0;
        checkCollideWithGoal = false;
        GetComponent<Collider2D>().enabled = false;
        //is_clear = false;
    }
    

    public void CheckHp(HP hp_bar)
    {
        HP.CheckHp(hp_bar, this.GetComponent<Player>());
    }

    public bool DeadCheck()
    {
        if (hp <= 0) return true;
        else return false;
    }

    void OnTriggerEnter2D(Collider2D goal)
    {
        if (goal.gameObject.tag == "goal")
        {
            checkCollideWithGoal = true;
           
            isClear = true;
            GameClear.Cleard(this);
        }
    }
    
    public bool NeedTurnPhase()
    {
        return moveToGoal.Count > 0;
    }

    public IEnumerator RunMovePhase()
    {
        GameObject passedLine = Instantiate(goalPoint);
        passedLine.transform.parent = this.transform;
        passedLine.GetComponent<LineRenderer>().SetPosition(0, PlayerGoalPosition[0]);
        
        while (true)
        {
            // isArrive = moveToGoal[0].IsArrive(transform);
            if (MoveToGoal.IsArrive(transform, PlayerGoalPosition[1]) == false)
            {
                MoveToGoal.Move1Frame(transform, PlayerGoalPosition[1], 5.0f);
                //moveToGoal[0].Move1Frame(transform);
                passedLine.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                //Debug.Log("그리는중");
            }
            else
            {
                PlayerGoalPosition.RemoveAt(0);
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator RunBattlePhase()
    {
        yield return new WaitForSeconds(1.0f);

        Enemy encounteredEnemy = moveToGoal[0].encounteredEnemy;
        if (encounteredEnemy != null)
        {
            ////////////
            if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 1.2f)
            {
                enemyInfoAnimation.SetTrigger("huge_attack");
                Debug.Log("attacked");
            }
            else if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 1.0f)
            {
                enemyInfoAnimation.SetTrigger("attack");
                Debug.Log("attacked");
            }
            else if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 0.8f)
            {
                enemyInfoAnimation.SetTrigger("small_attack");
                Debug.Log("attacked");
            }
            /////////////
            BattleSystem.Battle(this, encounteredEnemy, hpBar, encounteredEnemy.Enemy_Information.GetComponent<Enemy_HP>());
        }
        yield return null;
    }

    public void PhaseEnd()
    {
        if (moveToGoal[0].encounteredEnemy == null)
        {
            moveToGoal.RemoveAt(0);
        }
    }

    /*private GameObject NowLine()
    {
        for (int i = 0; i < LineDrawer.max_line.GetComponent<MaxLine_Turn>().Max_Line; i++)
        {
            if (LineDrawer.myLine[i] != null)
                return LineDrawer.myLine[i];
        }

        return null;
    }*/
}