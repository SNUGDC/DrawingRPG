using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LambdaTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("HI");

        int a = 3;
        Debug.Log("A is " + a);
        string b = "bString";
        Debug.Log("B is " + b);
        Action c = () =>
        {
            Debug.Log("I'm in action");
        };
        c();
        c();

        Action<int> d = (int myParameter) =>
        {
            Debug.Log("I'm d and parameter is " + myParameter);
        };
        d(3);
        d(5);

        //Action e = ParemterIntFunction;
        Action<int> f = ParemterIntFunction;
        f(4);

        Action<int, int> g = (x, y) => Debug.Log("a + b : " + (x + y));

        Func<int> h = () =>
        {
            return 3;
        };

        Func<int, string> i = (int z) =>
        {
            return "myString" + z;
        };

        Func<int, int, int, string> j = (a1, a2, a3) =>
        {
            return "";
        };

        Func<int, int, int> xx = (int b1, int b2) => b1 + b2;

        Func<int, Func<int, int>> zz =  x1 => x2 => x1 + x2;
        zz(1)(3);


    }

    void ParemterIntFunction(int a)
    {
        Debug.Log("ParemterIntFunction called with " + a);
    }

    Func<int> randomGenerator()
    {
        return () => 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
