using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneManager : MonoBehaviour {
    public GUISkin start;

    void OnGUI()
    {
        GUI.skin = start;
        if(GUI.Button(new Rect(500,100,100,50),"Game Start")==true)
        {
            Application.LoadLevel("Start");
        }
        if (GUI.Button(new Rect(500, 200, 100, 50), "Exit") == true)
        {
            Application.Quit();
        }
    }
}
