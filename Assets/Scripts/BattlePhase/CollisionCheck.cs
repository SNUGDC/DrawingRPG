using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    public List<Enemy> encountEnemy = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
            Debug.Log("플레이어충돌 스크립트 작동 Enter");
        //encountEnemy.Add(collision.);
    }
}
