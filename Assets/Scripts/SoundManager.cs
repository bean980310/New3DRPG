using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public int sfxVol = 6;
    public int musicVol = 6;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        sfxVol = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 30), sfxVol, 0.0f, 10.0f);
        GUI.Label(new Rect(Screen.width / 2 - 50 + 110, Screen.height / 2 - 5, 100, 30), "SFX : " + sfxVol);

        musicVol = (int)GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 30, 100, 30), musicVol, 0.0f, 10.0f);
        GUI.Label(new Rect(Screen.width / 2 - 50 + 110, Screen.height / 2 + 25, 100, 30), "Music : " + musicVol);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 90, 100, 30), "Close"))
        {
            Application.LoadLevel("Setting");
        }
    }
}
