using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhase : MonoBehaviour
{

    CollisionCheck collisionCheck;
    private List<PlayerAndGoals> playerAndItsGoalsList = new List<PlayerAndGoals>();
    public int maxTurnCount;

    public int turnCount;
    private bool running;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (running == false)
            {
                Debug.Log("2번누름");
                running = true;
                StartCoroutine(RunTurn());
            }
        }
    }

    public void StartBattlePhase(List<PlayerAndGoals> playerAndGoalsList)
    {
        this.playerAndItsGoalsList = playerAndGoalsList;
        running = true;
        StartCoroutine(RunTurn());
    }

    private IEnumerator RunTurn()
    {
        while (true)
        {

            Debug.Log("MoveTurn");
            yield return StartCoroutine(RunMoveTurn());
            Dictionary<GameObject, List<Element>> whichElementReachEnemy = new Dictionary<GameObject, List<Element>>();
            whichElementReachEnemy = OrganizeWhichElementReachEnemy();
            Debug.Log("BattleTurn");
            yield return StartCoroutine(RunBattleTurn(whichElementReachEnemy));

            RemoveGoal();
            TurnUI turnUI = FindObjectOfType<TurnUI>();
            turnCount++;
            turnUI.ActiveTurnUI();
        }
    }

    private void RemoveGoal()
    {
        foreach (var playerAndGoals in playerAndItsGoalsList)
        {
            var player = playerAndGoals.player;
            if (player == null)
            {
                continue;
            }

            if (playerAndGoals.goals.Count == 0)
            {
                continue;
            }

            var goal = playerAndGoals.goals[0];

            bool isArrive = PlayerPositionController.IsArrive(player.transform, goal.position);
            if (isArrive && goal.encountedEnemy == null)
            {
                playerAndGoals.goals.RemoveAt(0);
            }
        }
    }

    public IEnumerator RunMoveTurn() //목표지점으로 이동하는 함수
    {
        Dictionary<PlayerAndGoals, bool> arriveDic = new Dictionary<PlayerAndGoals, bool>();
        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            arriveDic[playerAndItsGoals] = false;
        }

        while (true)
        {
            foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
            {
                if (playerAndItsGoals.player == null || playerAndItsGoals.goals.Count == 0)
                {
                    arriveDic[playerAndItsGoals] = true;
                    continue;
                }

                Goal currentGoal = playerAndItsGoals.goals[0];

                if (arriveDic[playerAndItsGoals] == true) continue;

                Transform playerTransform = playerAndItsGoals.player.transform;
                Vector2 goalPosition = currentGoal.position;
                if (PlayerPositionController.IsArrive(playerTransform, goalPosition) == false)
                {
                    PlayerPositionController.Move1Frame(playerTransform, goalPosition, 5.0f);
                }
                else
                {
                    arriveDic[playerAndItsGoals] = true;
                }
            }
            yield return null;

            bool allArrive = true;
            foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
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

    public IEnumerator RunBattleTurn(Dictionary<GameObject, List<Element>> whichElementReachEnemy)
    {
        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            if (playerAndItsGoals.player == null)
            {
                continue;
            }
            if (playerAndItsGoals.goals.Count == 0)
            {
                continue;
            }

            Goal currentGoal = playerAndItsGoals.goals[0];

            if (currentGoal.encountedEnemy == null)
            {
                continue;
            }

            BattleSystem.Battle(playerAndItsGoals.player, currentGoal.encountedEnemy, whichElementReachEnemy);
        }
        yield return new WaitForSeconds(1.5f);
    }


    public Dictionary<GameObject, List<Element>> OrganizeWhichElementReachEnemy()
    {
        Dictionary<GameObject, List<Element>> whichElementReachEnemy = new Dictionary<GameObject, List<Element>>();

        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            if (playerAndItsGoals.player == null)
            {
                continue;
            }

            if (playerAndItsGoals.goals[0].encountedEnemy != null)
            {
                Player player = playerAndItsGoals.player.gameObject.GetComponent<Player>();
                GameObject enemy = playerAndItsGoals.goals[0].encountedEnemy;

                if (whichElementReachEnemy.ContainsKey(enemy) == false) {
                    whichElementReachEnemy[enemy] = new List<Element>();
                }
                whichElementReachEnemy[enemy].Add(player.element);
            }
        }

        return whichElementReachEnemy;
    }
}