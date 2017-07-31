using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private MoveAndBattlePhaseController MBcontroller;
    public List<Vector2> goals;
    public GameObject player;

    void Update()
    {
        float step = Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.0f,1.0f,0), step);
    }


    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    //if (other.tag == "enemy")
    //    {
    //        Debug.Log("적과 조우함");
    //        StartCoroutine(MBcontroller.RunBattelPhase());
    //        Destroy(other);
    //    }
    //}
}
