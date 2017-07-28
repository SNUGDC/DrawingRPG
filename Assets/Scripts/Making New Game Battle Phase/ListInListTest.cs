using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInListTest : MonoBehaviour {

    public Player emptyPlayer;
    public List<GoalList> allPlayerGoals = new List<GoalList>();

    private void Main()
    {
        

        for (int playerNum = 0; playerNum < 2; playerNum++)
        {
            List<Goal> goals = new List<Goal>();
            for (int goalNum = 0; goalNum < 10; goalNum++)
            {
                Vector2 goalPosition = new Vector2(goalNum, goalNum);
                Goal goal = new Goal(goalPosition);
                goals.Add(goal);
            }

            // need real player
            allPlayerGoals.Add(new GoalList(emptyPlayer, goals));

        }

        Debug.Log("3번쨰 테스트 : " + allPlayerGoals[1].goals[8].position);
    }
}
