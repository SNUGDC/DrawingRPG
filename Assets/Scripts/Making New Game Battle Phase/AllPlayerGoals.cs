using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerPositions : MonoBehaviour {

    //public Player emptyPlayer;
    //public List<GoalList> allPlayerGoals = new List<GoalList>();
    //enum players {player0, player1, player2 };
    public List<string> players = new List<string>();
    public List<Vector2> goalPosition;
    public Dictionary<string, List<Vector2>> allPlayerGoals = new Dictionary<string, List<Vector2>>();

    private void Start()
    {
        for (int playerNum = 0; playerNum < players.Count; playerNum++)
        {
            players.Add("Player" + playerNum);
            for (int goalNum = 0; goalNum < 10; goalNum++)
            {
                goalPosition.Add(new Vector2(goalNum, goalNum));
                allPlayerGoals.Add(players[playerNum], goalPosition);
            }
        }

        //디버그 찍으려하는데 뭔지모를 빨간줄 ㅜㅜ
        //foreach (KeyValuePair<string, List<Vector2>> allPlayersGoals in allPlayerGoals)
        //{
        //    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        //    Debug.Log("Key = {0}, Value = {1}", allPlayerGoals.Keys, allPlayerGoals.Values);
        //}

        //갓주형센세가 만들어놓은 건데 딕셔너리로 하려고 숨겨둠
        //for (int playerNum = 0; playerNum < 2; playerNum++)
        //{
        //    List<Goal> goals = new List<Goal>();
        //    for (int goalNum = 0; goalNum < 10; goalNum++)
        //    {
        //        Vector2 goalPosition = new Vector2(goalNum, goalNum);
        //        Goal goal = new Goal(goalPosition);
        //        goals.Add(goal);
        //    }
        //    // need real player
        //    allPlayerGoals.Add(new GoalList(emptyPlayer, goals));
        //}


    }

}

