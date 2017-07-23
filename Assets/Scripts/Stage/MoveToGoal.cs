using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal
{
    public Vector2 goal;
    public float moveSpeed = 5.0f;
    public Enemy encounteredEnemy;
    
    public static void Move1Frame(Transform transform, Vector2 goal, float moveSpeed)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;
        float buffer = 0.01f;

        if (distance >= buffer)
        {
            transform.position = (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime;
        }
    }
    public static bool IsArrive(Transform transform, Vector2 goal)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;

        return distance < 0.1f;
    }
    public MoveToGoal(Vector2 goal)
    {
        this.goal = goal;
    }
    
    public MoveToGoal(Vector2 goal, Enemy encounteredEnemy) : this(goal)
    {
        this.encounteredEnemy = encounteredEnemy;
    }

    public bool IsArrive(Transform transform)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;

        return distance < 0.1f;
    }

    public void Move1Frame(Transform transform)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;
        float buffer = 0.01f;

        if (distance >= buffer)
        {
            transform.position = (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime;
        }
    }
    /*public void Move1Frame(Vector2 start_position, Transform transform, GameObject line)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;
        float buffer = 0.01f;

        if (distance >= buffer)
        {
            //transform.position = (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime;
            line.GetComponent<LineRenderer>().SetPosition(0, start_position);
            line.GetComponent<LineRenderer>().SetPosition(1, (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime);
            transform.position = (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime;
        }
    }*/
}