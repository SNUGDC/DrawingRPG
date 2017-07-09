using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastTester : MonoBehaviour
{

    private Vector2 mousePos;
    private Vector3 mousePos3D;
    void Start()
    {

    }

    private List<Vector2> collisionPositions = new List<Vector2> ();
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // Debug.Log(mousePos);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, mousePos - new Vector2(transform.position.x ,transform.position.y));
        collisionPositions.Clear();
        if (hits.Length != 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                collisionPositions.Add(hits[i].point);
                Debug.Log(i.ToString() + hits[i].collider);
                
            }
        }


        mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3D.z = 0;
        RaycastHit[] hits3D = Physics.RaycastAll(transform.position,mousePos3D - new Vector3(transform.position.x, transform.position.y, transform.position.z));

        if (hits3D.Length != 0)
        {
            for (int i = 0; i < hits3D.Length; i++)
            {
                collisionPositions.Add(hits3D[i].point);
                Debug.Log("3d" + i.ToString() + hits3D[i].collider);

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