using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour {

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
}
