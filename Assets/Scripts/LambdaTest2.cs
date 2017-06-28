using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LambdaTest2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Action myAction = () => { };
        myAction();

        myAction += () =>
        {
            Debug.Log("New listener");
        };

        myAction();

        myAction += () =>
        {
            Debug.Log("New New Listener");
        };
        myAction();
    }
}
