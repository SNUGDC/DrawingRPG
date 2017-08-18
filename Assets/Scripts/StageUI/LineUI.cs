using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineUI : MonoBehaviour {

    public Text text;
    private DrawingPhase drawingPhase;

    private void Start()
    {
        drawingPhase = FindObjectOfType<DrawingPhase>();
        ActiveLineUI();
    }

    public void ActiveLineUI()
    {
        text.text = drawingPhase.remainLineCount + "/" + drawingPhase.totalLineCount;
    }
}
