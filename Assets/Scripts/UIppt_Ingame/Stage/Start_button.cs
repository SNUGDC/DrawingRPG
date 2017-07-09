using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_button : MonoBehaviour {

    public Button start_button;

    private void Start()
    {
        Button this_one = start_button.GetComponent<Button>();
    }

    private void Update()
    {
   //     OnClicked();
    }

    void OnClicked()
    {
        Debug.Log("Clicked");
    }
}
