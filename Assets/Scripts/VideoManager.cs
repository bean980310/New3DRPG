using UnityEngine;
using System.Collections;

public class VideoManager : MonoBehaviour {
    public int fieldOfView = 80;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        string[] qualities = QualitySettings.names;

        GUILayout.BeginVertical();

        for(int i = 0; i < qualities.Length; i++)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 120 + i * 30, 100, 30), qualities[i]))
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }

        GUILayout.EndVertical();

        fieldOfView = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 100, 20), fieldOfView, 30, 120);
        GUI.Label(new Rect(Screen.width / 2 - 50 + 110, Screen.height / 2 - 155, 100, 30), "FOV : " + fieldOfView);

        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 + 90, 100, 30), "Back"))
        {
            Application.LoadLevel("Setting");
        }
    }
}
