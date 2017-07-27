using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionClear : MonoBehaviour {

    public Player player;
    public Enemy enemy1;
    public Enemy enemy2;

    //public GameObject goal_Image;
    //public GameObject black;
    //public GameObject next;
    //private float duration = 3.0f;
    public bool is_clear;

    private void Start()
    {
        is_clear = false;
    }

    private void Update ()
    {
        if (player.checkCollideWithGoal == true)
        {
            MissionCompleteEvent();
        }

        if (enemy1==null && enemy2 == null)
        {
            MissionCompleteEvent();
        }
    }

   // public void checkMissionComplete()



    public void MissionCompleteEvent()
    {
        GameClear.Cleard();
    }

}
