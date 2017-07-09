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

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, );
        //if (hit.collider != null)
        //{

        
    }
}