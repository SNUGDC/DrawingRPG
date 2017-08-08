using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhase : MonoBehaviour
{

    CollisionCheck collisionCheck;
    private List<PlayerAndGoals> playerAndItsGoalsList = new List<PlayerAndGoals>();
    public List<GameObject> tempPlayer = new List<GameObject>();
    public List<GameObject> tempEnemy = new List<GameObject>();
    public int maxTurnCount;

    private int turnCount;
    private bool running;


    private void TempStart()
    {
        turnCount = 0;

        for (int i = 0; i < tempPlayer.Count; i++)
        {
            PlayerAndGoals playerAndItsGoals = new PlayerAndGoals();
            playerAndItsGoals.player = tempPlayer[i];

            for (int j = 0; j < maxTurnCount; j++)
            {
                Goal goal = new Goal(new Vector2(1.0f * j + 1, 1.0f * j + 2), null);
                playerAndItsGoals.goals.Add(goal);
            }
            playerAndItsGoals.goals[2].encountedEnemy = tempEnemy[0];
            playerAndItsGoals.goals[4].encountedEnemy = tempEnemy[1];
            playerAndItsGoalsList.Add(playerAndItsGoals);
        }

        running = false;
    }

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
            OrganizeWhoReachEnemy();
            Debug.Log("BattleTurn");
            yield return StartCoroutine(RunBattleTurn());

            RemoveGoal();
            turnCount++;
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

    public IEnumerator RunBattleTurn()
    {
        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            if (playerAndItsGoals.goals.Count == 0)
            {
                continue;
            }

            Goal currentGoal = playerAndItsGoals.goals[0];

            if (currentGoal.encountedEnemy == null)
            {
                continue;
            }

            BattleSystem.Battle(playerAndItsGoals.player, currentGoal.encountedEnemy);
        }
        yield return new WaitForSeconds(1.5f);
    }

    public void OrganizeWhoReachEnemy()
    {
        Dictionary<GameObject, List<GameObject>> whoReachEnemy = new Dictionary<GameObject, List<GameObject>>();
        foreach (GameObject enemy in tempEnemy)
        {
            List<GameObject> reachedPlayers = reachedPlayers = new List<GameObject>();
            foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
            {
                if (playerAndItsGoals.goals[0].encountedEnemy == enemy)
                {
                    reachedPlayers.Add(playerAndItsGoals.player);
                }
            }
            whoReachEnemy.Add(enemy, reachedPlayers);
        }
    }
}