using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour {

    public bool IsMovePhase;
    public bool IsBattlePhase;

    private void Start()
    {
        IsBattlePhase = false;
    }


    public IEnumerator RunBattelPhase()
    {
        Debug.Log("BattlePhase 시작");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("BattlePhase 끝");
        IsMovePhase = true;
        IsBattlePhase = false;
    }

    public IEnumerator RunMovePhase()
    {
        Debug.Log("MovePhase 시작");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("MovePhase 끝");
    }

}
