using UnityEngine;
using System.Collections;

public class CreditManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(150, 450, 225, 50), "Back") == true)
        {
            Application.LoadLevel("Title");
        }
    }
}
