using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_button : MonoBehaviour {

    public Button start_button;
    private LineDrawer LineDrawer;

    private void Start()
    {
        start_button.interactable = false;
        LineDrawer = GameObject.Find("LineDrawer").GetComponent<LineDrawer>();
    }

    private void Update()
    {
        if (LineDrawer.this_num != 0)
        {
            start_button.interactable = true;
        }
    }

    void OnClicked()
    {
        Debug.Log("Clicked");
    }
}
