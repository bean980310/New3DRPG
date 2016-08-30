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
        sfxVol = (int)GUI.HorizontalSlider(new Rect(225, 150, 100, 30), sfxVol, 0.0f, 10.0f);
        GUI.Label(new Rect(150, 150, 100, 30), "SFX : " + sfxVol);

        musicVol = (int)GUI.HorizontalSlider(new Rect(225, 225, 100, 30), musicVol, 0.0f, 10.0f);
        GUI.Label(new Rect(150, 225, 100, 30), "Music : " + musicVol);

        if (GUI.Button(new Rect(150, 375, 225, 50), "Back"))
        {
            Application.LoadLevel("Setting");
        }
    }
}
