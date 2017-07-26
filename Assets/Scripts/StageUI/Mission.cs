using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour {
    public GameObject start_button;
    
	void Start () {
        start_button.SetActive(false);
        Destroy(gameObject, 3);
	}
	
}
