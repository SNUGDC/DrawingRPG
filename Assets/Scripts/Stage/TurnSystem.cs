using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private bool startmove;
    public Player playerMover;

    public void StartMove()
    {
        startmove = true;
        StartCoroutine(RunTurn());
    }

    private void Start()
    {
        startmove = false;
        Screen.SetResolution(360, 640, false);
    }

    IEnumerator RunTurn()
    {
        while (playerMover.NeedTurnPhase())
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            if (playerMover == null)
            {
                yield break;
            }
            playerMover.PhaseEnd();
        }
        Debug.Log("TurnEnd");
    }

    private IEnumerator RunMovePhase()
    {
        yield return StartCoroutine(playerMover.RunMovePhase());
    }

    private IEnumerator RunBattlePhase()
    {
        yield return StartCoroutine(playerMover.RunBattlePhase());
    }
}
