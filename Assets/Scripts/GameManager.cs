using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public List<Character> Characters = new List<Character>();
    bool ShowCharWheel;
    public int SelectedCharacter;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowCharWheel = true;
        }
	}

    void OnGUI()
    {
        if (ShowCharWheel)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 64, Screen.height - 96, 64, 192), GUIContent.none, "box");
            foreach(Character c in Characters)
            {
                if (GUILayout.Button(c.Icon,GUILayout.Width(64),GUILayout.Height(64)))
                {
                    SelectedCharacter = Characters.IndexOf(c);
                }
            }
            GUILayout.EndArea();
        }
    }
}
[System.Serializable]
public class Character
{
    public string Name;
    public Texture2D Icon;
    public GameObject PlayerPrefab;
}
