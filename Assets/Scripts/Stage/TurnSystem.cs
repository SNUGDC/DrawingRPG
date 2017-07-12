using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private bool startmove;
    public PlayerMover playerMover;

    public void StartMove()
    {
        startmove = true;
        StartCoroutine(RunTurn());
    }

    private void Start()
    {
        startmove = false;
    }

    IEnumerator RunTurn()
    {
        while (playerMover.NeedTurnPhase())
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            playerMover.PhaseEnd();
        }
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
