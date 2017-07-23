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
    
    private List<Enemy> collisionEnemyList = new List<Enemy>();
    private List<Vector2> collisionPositionList = new List<Vector2>();
    void FixedUpdate()
    {
        collisionPositionList.Clear();
        collisionEnemyList.Clear();
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
                RaycastHit2D hit = hits[i];
                collisionPositionList.Add(hit.point);
                GameObject enemyGameObject = hit.collider.gameObject;
                collisionEnemyList.Add(enemyGameObject.GetComponent<Enemy>());
                //Debug.Log(i.ToString() + hit.collider);
            }
        }
    }

    public Vector2? GetNearestEnemyPosition(List<Enemy> ignoreList)
    {
        if (collisionPositionList.Count == 0)
        {
            return null;
        }

        for (int i = collisionPositionList.Count - 1; i >= 0; i--)
        {
            Enemy enemy = collisionEnemyList[i];
            if (ignoreList.Contains(enemy))
            {
                continue;
            }
            return collisionPositionList[i];
        }

        return null;
    }

    public Enemy GetNearestEnemy(List<Enemy> ignoreList)
    {
        if (collisionEnemyList.Count == 0)
        {
            return null;
        }

        for (int i = collisionEnemyList.Count - 1; i >= 0; i--)
        {
            Enemy enemy = collisionEnemyList[i];
            if (ignoreList.Contains(enemy))
            {
                continue;
            }
            return collisionEnemyList[i];
        }

        return null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, 1);

        foreach (var position in collisionPositionList)
        {
            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}