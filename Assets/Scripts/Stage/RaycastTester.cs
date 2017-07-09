using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastTester : MonoBehaviour
{

    private Vector2 mousePos;
    void Start()
    {

    }
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, mousePos - new Vector2(transform.position.x ,transform.position.y));

        if (hits.Length != 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider);
            }
        }

        else
        {
         //   Debug.Log(hits[].collider);
        }
    }
}