using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBattlePhaseController : MonoBehaviour
{

    CollisionCheck collisionCheck;
    private List<PlayerAndItsGoals> playerAndItsGoalsList = new List<PlayerAndItsGoals>();


    public List<GoalList> allPlayerGoals = new List<GoalList>();
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> tempEnemy = new List<GameObject>();
    //public GameObject temperaryEnemy;
    public int maxTurnCount;


    private int turnCount;
    private bool isMovePhase;
    private bool isBattlePhase;
    private bool isMoveAndBattlePhase;


    private void Start()
    {
        turnCount = 0;
        //for (int i = 0; i < PlayerAndItsGoals playerAndItsGoals.whenEncountEnemy;i++)
        //{
        //}

        for (int i = 0; i < players.Count; i++)
        {
            PlayerAndItsGoals playerAndItsGoals = new PlayerAndItsGoals();
            playerAndItsGoals.player = players[i];

            for (int j = 0; j < maxTurnCount; j++)
            {
                playerAndItsGoals.goals.Add(new Vector2(1.0f * j + 1, 1.0f * j + 2));
            }
            playerAndItsGoals.whenEncountEnemy.Add(2);
            playerAndItsGoals.whenEncountEnemy.Add(4);
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
        while (turnCount < maxTurnCount)
        {
            yield return StartCoroutine(RunMovePhase());
            yield return StartCoroutine(RunBattlePhase());
            turnCount++;
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
                if (playerAndItsGoals.whenEncountEnemy[0] != turnCount)
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
                        playerAndItsGoals.goals.RemoveAt(0);

                    }
                }

                else
                {
                    arriveDic[playerAndItsGoals] = true;
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
        foreach (PlayerAndItsGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            if ((playerAndItsGoals.ecountedEnemy[0] == null) && playerAndItsGoals.whenEncountEnemy[0] == turnCount
                && (playerAndItsGoals.goals[0].x == playerAndItsGoals.player.transform.position.x)
                && (playerAndItsGoals.goals[0].y == playerAndItsGoals.player.transform.position.y))
            { 
                continue;
            }

            if ((playerAndItsGoals.ecountedEnemy[0] != null) && playerAndItsGoals.whenEncountEnemy[0] == turnCount
                && (playerAndItsGoals.goals[0].x == playerAndItsGoals.player.transform.position.x)
                && (playerAndItsGoals.goals[0].y == playerAndItsGoals.player.transform.position.y))
            {
                BattleSystemForTemp.Battle(playerAndItsGoals.player, playerAndItsGoals.ecountedEnemy[0]);
                if (playerAndItsGoals.ecountedEnemy[0] == null)
                {
                    playerAndItsGoals.ecountedEnemy.RemoveAt(0);
                    playerAndItsGoals.whenEncountEnemy.RemoveAt(0);
                }
                else
                {
                    for (int i = 0; i < playerAndItsGoals.whenEncountEnemy.Count; i++)
                    {
                        playerAndItsGoals.whenEncountEnemy[i]++;
                    }
                }
            }
        }

        //적이 살아있는지 체크 적이 살아있다면 tempGoalPositions의 첫번째에 플레이어의 포지션을 다시 집어넣음

        Debug.Log("it is BattlePhase");
        yield return new WaitForSeconds(1.5f);
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