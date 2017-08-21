using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameEndChecker : MonoBehaviour
{

    public interface IRemainTurnSource
    {
        bool isRemainTurn();
    }

    public enum Result
    {
        NotEnd,
        AllEnemyDeath,
        AllPlayerDeath,
        TurnOver,
        NothingToDo
    }

    private List<Player> allPlayers;
    private List<Enemy> allEnemies;
    private IRemainTurnSource remainTurnSource;

    public GameEndChecker(List<Player> allPlayers, List<Enemy> allEnemies, IRemainTurnSource remainTurnSource)
    {
        this.allPlayers = allPlayers;
        this.allEnemies = allEnemies;
        this.remainTurnSource = remainTurnSource;
    }

    public Result Check(List<PlayerAndGoals> playerAndItsGoalsList)
    {
        if (CheckAllEnemyDeath())
        {
            return Result.AllEnemyDeath;
        }
        if (CheckAllPlayerDeath())
        {
            return Result.AllPlayerDeath;
        }
        if (CheckTurnOver())
        {
            return Result.TurnOver;
        }
        if (CheckNothingToDo(playerAndItsGoalsList))
        {
            return Result.NothingToDo;
        }

        return Result.NotEnd;
    }

    private bool CheckTurnOver()
    {
        return remainTurnSource.isRemainTurn() == false;
    }

    private bool CheckAllPlayerDeath()
    {
        return allPlayers.All(player => player == null);
    }

    private bool CheckAllEnemyDeath()
    {
        return allEnemies.All(enemy => enemy == null);
    }

    private bool CheckNothingToDo(List<PlayerAndGoals> playerAndItsGoalsList)
    {
        int remainGoalCount = 0;
        foreach (PlayerAndGoals playerAndItsGoals in playerAndItsGoalsList)
        {
            if (playerAndItsGoals.goals.Count != 0)
            {
                remainGoalCount++;
                Debug.Log("reaminGoalCount " + remainGoalCount);
            }
        }

        if (remainGoalCount == 0)
        { return true; }
        else { return false; }
    }
}