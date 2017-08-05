using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhase : MonoBehaviour
{

    CollisionCheck collisionCheck;
    private List<PlayerAndItsGoals> playerAndItsGoalsList = new List<PlayerAndItsGoals>();
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> tempEnemy = new List<GameObject>();
    public int maxTurnCount;

    private int turnCount;
    private bool running;


    private void Start()
    {
        turnCount = 0;

        for (int i = 0; i < players.Count; i++)
        {
            PlayerAndItsGoals playerAndItsGoals = new PlayerAndItsGoals();
            playerAndItsGoals.player = players[i];

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

    private IEnumerator RunTurn()
    {
        while (turnCount < maxTurnCount)
        {
            yield return StartCoroutine(RunMoveTurn());
            yield return StartCoroutine(RunBattleTurn());
            turnCount++;
        }
    }

    public IEnumerator RunMoveTurn() //목표지점으로 이동하는 함수
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
                Goal currentGoal = playerAndItsGoals.goals[0];
                if (currentGoal.encountedEnemy != null)
                {
                    arriveDic[playerAndItsGoals] = true;
                    continue;
                }

                if (arriveDic[playerAndItsGoals] == true) continue;

                Transform playerTransform = playerAndItsGoals.player.transform;
                Vector2 goalPosition = currentGoal.position;
                if (PlayerPositionController.IsArrive(playerTransform, goalPosition) == false)
                {
                    PlayerPositionController.Move1Frame(playerTransform, goalPosition, 1.0f);
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

    public IEnumerator RunBattleTurn()
    {
        foreach (PlayerAndItsGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            Goal currentGoal = playerAndItsGoals.goals[0];

            if (currentGoal.encountedEnemy == null)
            {
                continue;
            }

            BattleSystemForTemp.Battle(playerAndItsGoals.player, currentGoal.encountedEnemy);
            if (currentGoal.encountedEnemy == null)
            {
                playerAndItsGoals.goals.RemoveAt(0);
            }
        }
        Debug.Log("it is BattlePhase");
        yield return new WaitForSeconds(1.5f);
    }
}