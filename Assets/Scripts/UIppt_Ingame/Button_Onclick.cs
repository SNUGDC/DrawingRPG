using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Onclick : MonoBehaviour {
    public GameObject Building;
    public void BuildingSetActive()
    {
        Building.SetActive(!Building.active);
    }
}
