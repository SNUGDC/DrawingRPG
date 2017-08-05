using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndGoals
{
    public GameObject player;
    public List<Goal> goals = new List<Goal>();
}

public class Goal
{
    public Vector2 position;
    public GameObject encountedEnemy;

    public Goal(Vector2 position, GameObject encountedEnemy)
    {
        this.position = position;
        this.encountedEnemy = encountedEnemy;
    }
}