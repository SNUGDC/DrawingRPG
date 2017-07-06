using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_count : MonoBehaviour {
    int count_Lines=0;
    public int Limit_Lines;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
	void Update () {
        
        if (Input.GetMouseButtonDown(0) && count_Lines < Limit_Lines)
        {
            count_Lines++;
        }
        text.text = "Line " + count_Lines +  "/" + Limit_Lines;
	}

}
