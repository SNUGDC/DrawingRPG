using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private MoveAndBattlePhaseController MBcontroller;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Enemy"))
        {
            Debug.Log("적과 조우함");
            StartCoroutine(MBcontroller.RunBattelPhase());
            Destroy(other);
        }
    }
}
