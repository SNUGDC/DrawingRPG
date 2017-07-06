using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_select : MonoBehaviour {
    public static Menu_select instance = null;

    public Canvas Menu_canvas;
    public Canvas Back_canvas;
    public Canvas Option_canvas;
    public Canvas Main_Menu_canvas;

    public string select;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    public void select_menu(string select)
    {
        if (select == "Back")
            Back_Active();
        else if (select == "Option")
            Option_Active();
        else if (select == "Main_Menu")
            Main_Menu_Active();
    }

    public void Menu_Active()
    {
        Menu_canvas.enabled = true;
        Back_canvas.enabled = false;
        Option_canvas.enabled = false;
        Main_Menu_canvas.enabled = false;
    }
    public void Back_Active()
    {
        Debug.LogError("Baaaaaaaack");
        Back_canvas.enabled = true;
        Menu_canvas.enabled = false;
        Option_canvas.enabled = false;
        Main_Menu_canvas.enabled = false;
    }
    public void Option_Active()
    {
        Option_canvas.enabled = true;
        Back_canvas.enabled = false;
        Menu_canvas.enabled = false;
        Main_Menu_canvas.enabled = false;
    }
    public void Main_Menu_Active()
    {
        Main_Menu_canvas.enabled = true;
        Back_canvas.enabled = false;
        Option_canvas.enabled = false;
        Menu_canvas.enabled = false;
    }
}
