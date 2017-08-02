using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour {

    CollisionCheck collisionCheck;
    PlayerScript TempPlayer;
    public List<GoalList> allPlayerGoals = new List<GoalList>();

    public GameObject player;
    public int MaxTurnCount;

    private int TurnCount;
    private bool isMovePhase;
    private bool isBattlePhase;
    private bool isMoveAndBattlePhase;
    private List<Vector2> tempGoalPositions= new List<Vector2>();
    
    private void Start()
    {
        isMovePhase = false;
        isBattlePhase = false;
        isMoveAndBattlePhase = false;
        //플레이어가 가야될 목표를 받아야하는데 일단 임의 포지션으로 지정함)
        for (int i = 0; i < MaxTurnCount; i++)
        {
            tempGoalPositions.Add(new Vector2(1.0f*i,1.0f*i));
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

    public IEnumerator RunMovePhase() //목표지점으로 이동하는 함수
    {
        while (true)
        {
            if (PlayerPositionController.IsArrive(player.transform, tempGoalPositions[0]) == false)
            {
                PlayerPositionController.Move1Frame(player.transform, tempGoalPositions[0], 1.0f);
            }
            else
            {
                //여기다가 if 적과 조우상태면 remove함수 없고, 적과조우상태면 remove함수있음
                tempGoalPositions.RemoveAt(0);
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator RunBattlePhase()
    {
        //Enemy enemy = collisionCheck.encountEnemy[0];
        //BattleSystemForTemp.Battle(TempPlayer, enemy);
        //전투애니메이션 재생
        //적이 살아있는지 체크 적이 살아있다면 tempGoalPositions의 첫번째에 플레이어의 포지션을 다시 집어넣음
        //전투결과 애니메이션 재생
        //배틀페이즈종료
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
