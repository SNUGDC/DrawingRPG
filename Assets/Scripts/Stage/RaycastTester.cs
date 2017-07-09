using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastTester : MonoBehaviour
{

    private Vector2 mousePos;
    public Vector2? startPos;

    void Start()
    {

    }

    private List<Vector2> collisionPositions = new List<Vector2> ();
    void FixedUpdate()
    {
        collisionPositions.Clear();
        if (startPos == null)
        {
            return;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(mousePos);


        Vector2 direction = startPos.Value - mousePos;
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, direction, distance: Mathf.Infinity, layerMask: LayerMask.GetMask("Enemy"));
        
        if (hits.Length != 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                collisionPositions.Add(hits[i].point);

                Debug.Log(i.ToString() + hits[i].collider);
                
            }
        }
    }

    public Vector2? GetNeariestEnemy()
    {
        if(collisionPositions.Count == 0)
        {
            return null;
        }

        return collisionPositions[collisionPositions.Count-1];

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