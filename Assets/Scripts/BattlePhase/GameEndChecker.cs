using System;
using System.Collections.Generic;
using System.Linq;

public class GameEndChecker
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
        TurnOver
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

    public Result Check()
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
}