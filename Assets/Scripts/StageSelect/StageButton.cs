using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public int stage;
    public Image stageImage;
    public List<Sprite> Flags;
    void Awake()
    {
        int lastClearedStage = SaveManager.LoadLastClearedStage();
        
        if (stage == lastClearedStage)
        {
            stageImage.sprite = Flags[1];
            GetComponent<Button>().interactable = true;
        }
        else if (stage < lastClearedStage)
        {
            stageImage.sprite = Flags[0];
            GetComponent<Button>().interactable = true;
        }
        else
        {
            stageImage.sprite = null;
            GetComponent<Button>().interactable = false;
        }
    }
}
