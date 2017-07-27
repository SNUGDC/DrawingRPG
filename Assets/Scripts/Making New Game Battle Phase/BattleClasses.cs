using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Vector2 position;

    public Goal(Vector2 position)
    {
        this.position = position;
    }
}

public class GoalList
{
    public Player player;
    public List<Goal> goals;

    public GoalList(Player player, List<Goal> goals)
    {
        this.player = player;
        this.goals = goals;
    }
}
