using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour {


    private MoveAndBattlePhaseController MBcontroller;

    private ListInListTest ListInListTest;
    public List<Vector2> goals;
    public GameObject player;



    void Update()
    {
        {
            player.transform.position += new Vector3(0.3f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            //ListInListTest.allPlayerGoals[0].goals[2].position;
        }
    }

}

