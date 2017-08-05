using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DrawingPhase : MonoBehaviour
{

    public int totalLineCount = 5;

    private List<Drawer> drawers = new List<Drawer>();
    private int remainLineCount;

    void FindDrawers()
    {
        this.drawers = FindObjectsOfType<Drawer>().ToList();
    }

    // Use this for initialization
    void Start()
    {
        FindDrawers();
        foreach (Drawer drawer in drawers)
        {
            drawer.StartDrawingPhase(this);
        }
        remainLineCount = totalLineCount;
    }

    public void UseLineCount()
    {
        this.remainLineCount -= 1;
    }

    public bool HaveDrawingTurn()
    {
        return remainLineCount > 0;
    }
}
