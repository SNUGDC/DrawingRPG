using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal
{
    public Vector2 goal;
    public float moveSpeed = 5.0f;
    public MoveToGoal(Vector2 goal)
    {
        this.goal = goal;
    }

    public bool IsArrive(Transform transform)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;

        return distance < 0.1f;
    }

    public void Move(Transform transform)
    {
        Vector2 playerPos = transform.position;
        float distance = (playerPos - goal).magnitude;
        float buffer = 0.01f;

        if (distance >= buffer)
        {
            transform.position = (Vector2)transform.position + (goal - playerPos).normalized * moveSpeed * Time.deltaTime;
        }
    }
}