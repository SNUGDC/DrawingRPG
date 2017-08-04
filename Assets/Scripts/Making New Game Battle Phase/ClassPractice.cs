using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndItsGoals
{
    public GameObject player;
    public List<Vector2> goals = new List<Vector2>();
    public List<GameObject> ecountedEnemy = new List<GameObject>();
    public List<int> whenEncountEnemy = new List<int>();
    public List<int> playerMaxTurnCount = new List<int>();
}
