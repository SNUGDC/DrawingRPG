using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line_count : MonoBehaviour {
    public LineDrawer LineDrawer;
    int count_Lines=0;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
	void Update () {
        
        if (count_Lines < LineDrawer.maxLineNum && LineDrawer.myLine[count_Lines] != null)
        {
            count_Lines++;
        }
        text.text = "Line " + count_Lines +  "/" + LineDrawer.maxLineNum;
	}

}
