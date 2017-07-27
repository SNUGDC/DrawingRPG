using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInListTest : MonoBehaviour {

    private void Main() {
        List<GoalList> allPlayerGoals = new List<GoalList>();

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
            Player emptyPlayer = null;
            allPlayerGoals.Add(new GoalList(emptyPlayer, goals));

        }


        List<List<int>> testList = new List<List<int>>();
        List<int> testSubList1 = new List<int>();
        List<int> testSubList2 = new List<int>();
        List<int> testSubList3 = new List<int>();


        for (int i = 0; i<5; i++)
        {
            testSubList1.Add(i);
        }
        for (int i = 0; i < 5; i++)
        {
            testSubList2.Add(i + 10);
        }
        for (int i = 0; i < 5; i++)
        {
            testSubList3.Add(i + 20);
        }
        testList.Add(testSubList1);
        testList.Add(testSubList2);
        testList.Add(testSubList3);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Debug.Log(testList[i][j]);
            }
        }
    }
}
