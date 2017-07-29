using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeStartUI : MonoBehaviour {
    
    public GameObject lineDisplayPanel;
    public GameObject mission;
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject afterStartUI;
    public GameObject allPlayerInformationPanel;
    public GameObject allEnemyFieldHPPanel;

    IEnumerator ShowMission(float second)
    {
        yield return new WaitForSeconds(second);
        InstantiateLineDisplayPanel();
        InstantiateStartButton();
        InstantiateStopButton();
        InstantiateAllPlayerInfoPanel();
        InstantiateAllEnemyFieldHPPanel();
    }
    
    private void InstantiateMission()
    {
        Instantiate(mission, this.transform);
    }
    private void InstantiateLineDisplayPanel()
    {
        Instantiate(lineDisplayPanel, this.transform);
    }
    private void InstantiateStartButton()
    {
        Instantiate(startButton, this.transform);
    }
    private void InstantiateStopButton()
    {
        Instantiate(stopButton, this.transform);
    }
    public void InstantiateAfterStartUI()
    {
        Instantiate(afterStartUI, this.transform.parent);
    }
    private void InstantiateAllPlayerInfoPanel()
    {
        Instantiate(allPlayerInformationPanel, this.transform);
    }
    private void InstantiateAllEnemyFieldHPPanel()
    {
        Instantiate(allEnemyFieldHPPanel, this.transform);
    }

    private void Start()
    {
        InstantiateMission();
        StartCoroutine(ShowMission(3.0f));
    }

    public void OnClickStartButton()
    {
        GameObject beforeStartUI = GameObject.Find("BeforeStartUI");
        beforeStartUI.GetComponent<BeforeStartUI>().InstantiateAfterStartUI();
        Destroy(beforeStartUI);
    }
}
