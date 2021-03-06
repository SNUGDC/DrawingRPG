﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattlePhase : MonoBehaviour, GameEndChecker.IRemainTurnSource
{

    CollisionCheck collisionCheck;
    private List<PlayerAndGoals> playerAndItsGoalsList = new List<PlayerAndGoals>();

    public int stageNumber;

    public int maxTurnCount;

    public int turnCount;
    private bool running;

    private GameEndChecker gameEndChecker;

    void Awake()
    {
        var players = GameObject.FindObjectsOfType<Player>();
        var enemies = GameObject.FindObjectsOfType<Enemy>();
        gameEndChecker = new GameEndChecker(
            allPlayers: players.ToList(),
            allEnemies: enemies.ToList(),
            remainTurnSource: this);
        turnCount = 1;
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
        if (Input.GetKeyUp(KeyCode.Q))
        {
            UIManager.Instance.Cleard();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            UIManager.Instance.GameOver();
        }
    }

    public void StartBattlePhase(List<PlayerAndGoals> playerAndGoalsList, int remainLineCount)
    {
        this.playerAndItsGoalsList = playerAndGoalsList;
        running = true;

        var maxLineCount = playerAndGoalsList.Max(goalList => goalList.goals.Count);

        this.maxTurnCount = remainLineCount + maxLineCount;
        
        StartCoroutine(RunTurn());
    }

    private IEnumerator RunTurn()
    {
        while (true)
        {
            UIManager.Instance.ActiveTurnUI(turnCount, maxTurnCount);
            Debug.Log("MoveTurn");
            yield return StartCoroutine(RunMoveTurn());
            Dictionary<GameObject, List<Element>> whichElementReachEnemy = new Dictionary<GameObject, List<Element>>();
            whichElementReachEnemy = OrganizeWhichElementReachEnemy();
            Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy = new Dictionary<GameObject, List<GameObject>>();
            whichPlayerReachEnemy = OrganizeWhichPlayerReachEnemy();
            Debug.Log("BattleTurn");
            yield return StartCoroutine(RunBattleTurn(whichElementReachEnemy,whichPlayerReachEnemy));

            RemoveGoal();
            turnCount++;



            if (CheckAndHandleEnd())
            {
                Debug.Log("End of RunTurn");
                break;
            }

        }
    }

    private bool CheckAndHandleEnd()
    {
        var endResult = gameEndChecker.Check(playerAndItsGoalsList);

        if (endResult != GameEndChecker.Result.NotEnd)
        {
            Debug.Log("Game end cause of " + endResult);
        }



        switch (endResult)
        {
            case GameEndChecker.Result.NotEnd:
                return false;
            case GameEndChecker.Result.AllEnemyDeath:
                UIManager.Instance.Cleard();
                ExperiencePoint.GetStageExperiencePoint(stageNumber, playerAndItsGoalsList);
                return true;
            case GameEndChecker.Result.AllPlayerDeath:
                UIManager.Instance.GameOver();
                ExperiencePoint.GetExperiencePoint(playerAndItsGoalsList);
                return true;
            case GameEndChecker.Result.TurnOver:
                UIManager.Instance.GameOver();
                ExperiencePoint.GetExperiencePoint(playerAndItsGoalsList);
                return true;
            case GameEndChecker.Result.NothingToDo:
                UIManager.Instance.GameOver();
                ExperiencePoint.GetExperiencePoint(playerAndItsGoalsList);
                return true;
            default:
                Debug.LogError("Invalid game end " + endResult);
                return false;
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
        Skill skill;
        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            Player player = playerAndItsGoals.player.gameObject.GetComponent<Player>();
            if (player.characterName == Player.CharacterName.Hesmen)
            {
                skill = new HpRecovery();
                if (skill.activated)
                    skill.Use(player);
            }

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
                    LineController linecont = LineController.FindLineWithNum(playerAndItsGoals.player.GetComponent<Player>(), playerAndItsGoals.player.GetComponent<Player>().lineNum);
                    linecont.PlayerMove();
                    PlayerPositionController.Move1Frame(playerTransform, goalPosition, 5.0f);
                }
                else
                {
                    LineController linecont = LineController.FindLineWithNum(playerAndItsGoals.player.GetComponent<Player>(), playerAndItsGoals.player.GetComponent<Player>().lineNum);
                    linecont.PlayerAfterMove();
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

    public IEnumerator RunBattleTurn(Dictionary<GameObject, List<Element>> whichElementReachEnemy, Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy)
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
                playerAndItsGoals.player.GetComponent<Player>().lineNum++;
                continue;
            }
            
            BattleSystem.Battle(playerAndItsGoals.player, currentGoal.encountedEnemy, whichElementReachEnemy, whichPlayerReachEnemy);
            Animator anim =playerAndItsGoals.player.GetComponentInChildren<Animator>();
            anim.SetTrigger("Attack");
            new WaitForSeconds(1.0f);
            anim.SetTrigger("Idle");

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

            if (playerAndItsGoals.goals.Count == 0)
            {
                continue;
            }

            if (playerAndItsGoals.goals[0].encountedEnemy != null)
            {
                Player player = playerAndItsGoals.player.gameObject.GetComponent<Player>();
                GameObject enemy = playerAndItsGoals.goals[0].encountedEnemy;

                if (whichElementReachEnemy.ContainsKey(enemy) == false)
                {
                    whichElementReachEnemy[enemy] = new List<Element>();
                }
                whichElementReachEnemy[enemy].Add(player.element);
            }
        }

        return whichElementReachEnemy;
    }

    public Dictionary<GameObject, List<GameObject>> OrganizeWhichPlayerReachEnemy()
    {
        Dictionary<GameObject, List<GameObject>> whichPlayerReachEnemy = new Dictionary<GameObject, List<GameObject>>();

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

            if (playerAndItsGoals.goals[0].encountedEnemy != null)
            {
                Player player = playerAndItsGoals.player.gameObject.GetComponent<Player>();
                GameObject enemy = playerAndItsGoals.goals[0].encountedEnemy;

                if (whichPlayerReachEnemy.ContainsKey(enemy) == false)
                {
                    whichPlayerReachEnemy[enemy] = new List<GameObject>();
                }
                whichPlayerReachEnemy[enemy].Add(player.gameObject);
            }
        }

        return whichPlayerReachEnemy;
    }

    bool GameEndChecker.IRemainTurnSource.isRemainTurn()
    {
        return this.turnCount <= this.maxTurnCount;
    }
}