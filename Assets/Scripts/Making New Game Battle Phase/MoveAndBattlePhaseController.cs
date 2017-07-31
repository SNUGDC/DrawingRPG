using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour {

    public List<GoalList> allPlayerGoals = new List<GoalList>();

    public GameObject player;
    public int MaxTurnCount;

    private int TurnCount;
    private bool isMovePhase;
    private bool isBattlePhase;
    private bool isMoveAndBattlePhase;
    private List<Vector3> tempGoalPositions= new List<Vector3>();
    
    private void Start()
    {
        isMovePhase = false;
        isBattlePhase = false;
        isMoveAndBattlePhase = false;
        //플레이어가 가야될 목표를 받아야하는데 일단 임의 포지션으로 지정함)
        for (int i = 0; i < MaxTurnCount; i++)
        {
            tempGoalPositions.Add(new Vector3(1.0f*i,1.0f*i,0));
            TurnCount++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isMoveAndBattlePhase == false)
            {
                Debug.Log("2번누름");
                isMoveAndBattlePhase = true;
                StartCoroutine(RunMoveAndBattePhase());
            }
        }    
    }

    private IEnumerator RunMoveAndBattePhase()
    {
        while (TurnCount > 0)
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            TurnCount--;
        }
    }

    public IEnumerator RunMovePhase()
    {
        player.transform.position = tempGoalPositions[0];
        tempGoalPositions.RemoveAt(0);
        Debug.Log("it is MovePhase");
        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator RunBattlePhase()
    {
        Debug.Log("it is BattlePhase");
        yield return new WaitForSeconds(1.0f);
    }

    




    //public IEnumerator RunBattlePhase()
    //{
    //    yield return new WaitForSeconds(1.0f);

    //    Enemy encounteredEnemy = moveToGoal[0].encounteredEnemy;
    //    if (encounteredEnemy != null)
    //    {
    //        //////////
    //        if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 1.2f)
    //        {
    //            enemyInfoAnimation.SetTrigger("huge_attack");
    //            Debug.Log("attacked");
    //        }
    //        else if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 1.0f)
    //        {
    //            enemyInfoAnimation.SetTrigger("attack");
    //            Debug.Log("attacked");
    //        }
    //        else if (BattleSystem.CheckElement(this.element, encounteredEnemy.element) == 0.8f)
    //        {
    //            enemyInfoAnimation.SetTrigger("small_attack");
    //            Debug.Log("attacked");
    //        }
    //        ///////////
    //        BattleSystem.Battle(this, encounteredEnemy);
    //    }
    //    yield return null;
    //}

    //public void PhaseEnd()
    //{
    //    if (moveToGoal[0].encounteredEnemy == null)
    //    {
    //        moveToGoal.RemoveAt(0);
    //    }
    //}

}
