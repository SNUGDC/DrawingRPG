using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour {

    public bool IsMovePhase;
    public bool IsBattlePhase;

    public List<GoalList> allPlayerGoals = new List<GoalList>();

    //private void Start()
    //{
    //    IsBattlePhase = false;
    //    allPlayerGoals = BirngAllPlayerGoals();
    //}

    
    


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
