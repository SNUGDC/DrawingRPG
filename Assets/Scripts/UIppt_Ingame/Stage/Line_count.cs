using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_count : MonoBehaviour {
    public LineDrawer LineDrawer;
    int count_Lines=0;
    public int Limit_Lines;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
	void Update () {
        
        if (LineDrawer.myLine[count_Lines] != null)
        {
            count_Lines++;
        }
        text.text = "Line " + count_Lines +  "/" + Limit_Lines;
	}

}
