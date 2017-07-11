using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Button : MonoBehaviour {
    
    void OnClick_to_scene(string scene)
    {
        SceneLoader.LoadScene_using_string(scene);
    }
    
}
