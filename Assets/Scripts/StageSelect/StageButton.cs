using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public int stage;
    void Awake()
    {
        int lastClearedStage = SaveManager.LoadLastClearedStage();

        if (stage <= lastClearedStage + 1)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
