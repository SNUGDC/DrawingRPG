using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private LineDrawer LineDrawer;
    public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();

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

    public void PhaseEnd()
    {
        moveToGoal.RemoveAt(0);
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
        Debug.Log("Here is battle phase");
        yield return new WaitForSeconds(1.0f);
        Enemy encounteredEnemy = moveToGoal[0].encounteredEnemy;
        if (encounteredEnemy != null)
        {
            Destroy(encounteredEnemy.gameObject);
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