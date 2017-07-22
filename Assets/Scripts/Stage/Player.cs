using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private LineDrawer LineDrawer;
    public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();
    public HP hp_bar;

    public GameObject Black;
    public GameObject Clear;
    public GameObject Fail;
    public GameObject Next_Stage;
    public GameObject Again_Stage;
    public GameObject Move_Battle_Panel;
    public int atk;
    public int max_hp;
    public int hp;
    public int speed;
    public int move_count;
    public bool is_clear=false;
    //public string element;
    public Element element;

    public Animator enemy_info_animation;

    private void Start()
    {
        move_count = 0;
        LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
    }
    
    public void check_hp(HP hp_bar)
    {
        HP.check_hp(hp_bar, this.GetComponent<Player>());
    }

    void OnTriggerEnter2D(Collider2D goal)
    {
        if (goal.gameObject.tag == "goal")
        {
            is_clear = true;
            GameClear.cleard(this);
        }
    }
    
    public bool NeedTurnPhase()
    {
        return moveToGoal.Count > 0;
    }

    public IEnumerator RunMovePhase()
    {

        while (true)
        {
            bool isArrive = moveToGoal[0].IsArrive(transform);
            if (isArrive == false)
            {
                moveToGoal[0].Move1Frame(transform);
            }
            else
            {
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
            if (BattleSystem.check_Element(this.element, encounteredEnemy.element) == 1.2f)
            {
                enemy_info_animation.SetTrigger("huge_attack");
                Debug.Log("attacked");
            }
            else if (BattleSystem.check_Element(this.element, encounteredEnemy.element) == 1.0f)
            {
                enemy_info_animation.SetTrigger("attack");
                Debug.Log("attacked");
            }
            else if (BattleSystem.check_Element(this.element, encounteredEnemy.element) == 0.8f)
            {
                enemy_info_animation.SetTrigger("small_attack");
                Debug.Log("attacked");
            }
            /////////////
            BattleSystem.Battle(this, encounteredEnemy, hp_bar, encounteredEnemy.Enemy_Information.GetComponent<Enemy_HP>());
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

    private GameObject NowLine()
    {
        for (int i = 0; i < LineDrawer.max_line.GetComponent<MaxLine_Turn>().Max_Line; i++)
        {
            if (LineDrawer.myLine[i] != null)
                return LineDrawer.myLine[i];
        }

        return null;
    }
}