using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneManager : MonoBehaviour {
    public GUISkin start;

    void OnGUI()
    {
        GUI.skin = start;
        if(GUI.Button(new Rect(150,150,225,50),"Game Start")==true)
        {
            Application.LoadLevel("Start");
        }
        if (GUI.Button(new Rect(150, 225, 225, 50), "Netplay Game") == true)
        {
            Application.LoadLevel("NetworkMenu");
        }
        if (GUI.Button(new Rect(150, 300, 225, 50), "Shop") == true)
        {
            
        }
        if (GUI.Button(new Rect(150, 375, 225, 50), "Setting") == true)
        {
            Application.LoadLevel("Setting");
        }
        if (GUI.Button(new Rect(150, 450, 225, 50), "Exit") == true)
        {
            Application.Quit();
        }
        if(GUI.Button(new Rect(Screen.width/1.3f, Screen.height/1.2f, 225, 50), "Credit") == true)
        {
            //Application.LoadLevel("Credit");
        }
    }
}
