using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();

    //public GameObject goal_Image;
    //public GameObject black;
    //public GameObject next;
    //private float duration = 3.0f;
    public bool is_clear;

    private void Start()
    {
        is_clear = false;
    }

    private void Update()
    {
        if (player.checkCollideWithGoal == true)
        {
            MissionCompleteEvent();
        }

        int enemyDeadCount = 0;
        foreach (Enemy element in enemies)
        {
            if (element != null) break;
            else enemyDeadCount++;
        }

        if (enemyDeadCount == enemies.Count)
            MissionCompleteEvent();

    }

    // public void checkMissionComplete()

    public void MissionCompleteEvent()
    {
        UIManager.Cleard();
    }
}
