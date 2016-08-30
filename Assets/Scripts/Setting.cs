using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(150, 150, 225, 50), "Audio Setting"))
        {
            Application.LoadLevel("Sound");
        }

        if (GUI.Button(new Rect(150, 225, 225, 50), "Video Setting"))
        {
            Application.LoadLevel("Video");
        }
        if (GUI.Button(new Rect(150, 300, 225, 50), "Display Setting"))
        {
            //Application.LoadLevel("Display");
        }
        if (GUI.Button(new Rect(150, 375, 225, 50), "Back"))
        {
            Application.LoadLevel("Title");
        }
    }
}
