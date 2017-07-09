using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private LineDrawer LineDrawer;
    private bool startmove;
    public List<MoveToGoal> moveToGoal = new List<MoveToGoal>();

    public int move_count;

    public void StartMove()
    {
        startmove = true;
        StartCoroutine(RunTurn());
    }

    private void Start()
    {
        move_count = 0;
        startmove = false;
        LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
    }

    IEnumerator RunTurn()
    {
        while (moveToGoal.Count > 0)
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            moveToGoal.RemoveAt(0);
        }
    }

    private IEnumerator RunMovePhase()
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

    private IEnumerator RunBattlePhase()
    {
        Debug.Log("Here is battle phase");
        Enemy encounteredEnemy = moveToGoal[0].encounteredEnemy;
        if (encounteredEnemy != null)
        {
            Destroy(encounteredEnemy.gameObject);
        }
        yield return new WaitForSeconds(1.0f);
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