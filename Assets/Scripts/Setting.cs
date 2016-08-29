using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 225, 50), "Audio Setting"))
        {
            Application.LoadLevel("Sound");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 225, 50), "Video Setting"))
        {
            Application.LoadLevel("Video");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 125, 225, 50), "Back"))
        {
            Application.LoadLevel("Title");
        }
    }
}
