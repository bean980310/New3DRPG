using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class GameManager : MonoBehaviour {
    public List<Character> Characters = new List<Character>();
    bool ShowCharWheel;
    public int SelectedCharacter;
    int LastCharacter;

    void Awake()
    {
        foreach (Character c in Characters)
        {
            c.Instance = Instantiate(c.PlayerPrefab, c.HomeSpawn.position, c.HomeSpawn.rotation) as GameObject;
        }
        ChangeCharacter(Characters[PlayerPrefs.GetInt("SelectedChar")]);
    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C))
        {
            ShowCharWheel = true;
        }
        else
        {
            ShowCharWheel = false;
        }      
	}
    void ChangeCharacter(Character c)
    {
        LastCharacter = SelectedCharacter;
        SelectedCharacter = Characters.IndexOf(c);
        Characters[LastCharacter].Instance.GetComponent<PlayerController>().CanPlay = false;
        Characters[SelectedCharacter].Instance.GetComponent<PlayerController>().CanPlay = true;
        Camera.main.GetComponent<SmoothFollow>().target = Characters[SelectedCharacter].Instance.transform;
        PlayerPrefs.SetInt("SelectedChar", SelectedCharacter);
    }

    void OnGUI()
    {
        if (ShowCharWheel)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 64, Screen.height - 192, 64, 192));
            foreach(Character c in Characters)
            {
                if (GUILayout.Button(c.Icon,GUILayout.Width(64),GUILayout.Height(64)))
                {
                    ChangeCharacter(c);
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
    public GameObject Instance;
    public Transform HomeSpawn;
}
