using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DrawingPhase : MonoBehaviour
{

    public int totalLineCount = 5;

    private List<Drawer> drawers = new List<Drawer>();
    private int remainLineCount;
    private List<PlayerAndGoals> playerAndGoalsList = new List<PlayerAndGoals>();

    void FindDrawers()
    {
        this.drawers = FindObjectsOfType<Drawer>().ToList();
    }

    // Use this for initialization
    void Start()
    {
        FindDrawers();
        foreach (Drawer drawer in drawers)
        {
            drawer.StartDrawingPhase(this);
            PlayerAndGoals playerAndGoals = new PlayerAndGoals();
            playerAndGoals.player = drawer.transform.parent.gameObject;
            playerAndGoalsList.Add(playerAndGoals);
        }
        remainLineCount = totalLineCount;
    }

    public void OnLineDrawComplete(GameObject player, Vector2 position, GameObject encountedEnemy)
    {
        this.remainLineCount -= 1;

        PlayerAndGoals playerAndGoals = FindPlayerAndGoals(player);
        Goal goal = new Goal(position, encountedEnemy);
        playerAndGoals.goals.Add(goal);
    }

    private PlayerAndGoals FindPlayerAndGoals(GameObject player)
    {
        foreach (var playerAndGoals in playerAndGoalsList)
        {
            if (playerAndGoals.player == player)
            {
                return playerAndGoals;
            }
        }

        return null;
    }

    public bool HaveDrawingTurn()
    {
        return remainLineCount > 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BattlePhase battlePhase = GetComponent<BattlePhase>();
            battlePhase.StartBattlePhase(playerAndGoalsList);

            foreach (var drawer in drawers)
            {
                Destroy(drawer.gameObject);
            }
        }
    }
}
