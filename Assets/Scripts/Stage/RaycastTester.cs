using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastTester : MonoBehaviour
{

    private Vector2 mousePos;

    void Start()
    {

    }

    private List<Vector2> collisionPositions = new List<Vector2> ();
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // Debug.Log(mousePos);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, new Vector2(transform.position.x ,transform.position.y)- mousePos);
        collisionPositions.Clear();
        if (hits.Length != 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                collisionPositions.Add(hits[i].point);
                Debug.Log(i.ToString() + hits[i].collider);
                
            }
        }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, 1);

        foreach (var position in collisionPositions)
        {
            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}