using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour {

    CollisionCheck collisionCheck;
    private List<PlayerAndItsGoals> playerAndItsGoalsList = new List<PlayerAndItsGoals>();


    public List<GoalList> allPlayerGoals = new List<GoalList>();
    public List<GameObject> players = new List<GameObject>();
    public int maxTurnCount;
    

    private int turnCount;
    private bool isMovePhase;
    private bool isBattlePhase;
    private bool isMoveAndBattlePhase;


    private void Start()
    {
        turnCount = maxTurnCount;
        for (int i = 0; i < players.Count; i++)
        {
            PlayerAndItsGoals playerAndItsGoals = new PlayerAndItsGoals();
            playerAndItsGoals.player = players[i];
            
            for (int j = 0; j < maxTurnCount; j++)
            {
                playerAndItsGoals.goals.Add(new Vector2(1.0f * j, 1.0f * j));
            }
            playerAndItsGoalsList.Add(playerAndItsGoals);
        }


        isMovePhase = false;
        isBattlePhase = false;
        isMoveAndBattlePhase = false;
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
        while (turnCount > 0)
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            turnCount--;
        }
    }

    public IEnumerator RunMovePhase() //목표지점으로 이동하는 함수
    {

        Dictionary<PlayerAndItsGoals, bool> arriveDic = new Dictionary<PlayerAndItsGoals, bool>();

        foreach (PlayerAndItsGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            arriveDic[playerAndItsGoals] = false;
        }

        while (true)
        {
            foreach (PlayerAndItsGoals playerAndItsGoals in playerAndItsGoalsList)
            {
                if (arriveDic[playerAndItsGoals] == true) continue;

                Transform playerTransform = playerAndItsGoals.player.transform;
                Vector2 nearGoal = playerAndItsGoals.goals[0];
                if (PlayerPositionController.IsArrive(playerTransform, nearGoal) == false)
                {
                    PlayerPositionController.Move1Frame(playerTransform, nearGoal, 1.0f);
                }
                else
                {
                    arriveDic[playerAndItsGoals] = true;
                    //여기다가 if 적과 조우상태면 remove함수 없고, 적과조우상태면 remove함수있음
                    playerAndItsGoals.goals.RemoveAt(0);
                    //도착할때마다 임의의값 +1

                    //임의의값 =플레이어수 
                }
            }


            yield return null;

            bool allArrive = true;
            foreach (PlayerAndItsGoals playerAndItsGoals in playerAndItsGoalsList)
            {
                if (arriveDic[playerAndItsGoals] == false)
                {
                    allArrive = false;
                }
            }

            if (allArrive)
            {
                yield break;
            }
        }
    }

    public IEnumerator RunBattlePhase()
    {
        //Enemy enemy = collisionCheck.encountEnemy[0];
        //BattleSystemForTemp.Battle(tempPlayer, enemy);
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
