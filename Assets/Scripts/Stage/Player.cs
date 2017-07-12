using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LineDrawer LineDrawer;
    public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();

    public int atk;
    public int hp;

    public int move_count;

    private void Start()
    {
        move_count = 0;
        LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
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
            BattleSystem.Battle(this, encounteredEnemy);
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
        for (int i = 0; i < LineDrawer.maxLineNum; i++)
        {
            if (LineDrawer.myLine[i] != null)
                return LineDrawer.myLine[i];
        }

        return null;
    }
}