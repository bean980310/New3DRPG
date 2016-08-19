using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Utility;

public class GameManager : MonoBehaviour {
    public List<Character> Characters = new List<Character>();
    public List<Item> AllItems = new List<Item>();
    public LootChest[] AllChests;
    public Character CurrentCharacter;
    bool ShowCharWheel;
    public int SelectedCharacter;
    int LastCharacter;
    public static GameManager Instance;
    public bool CanShowSwitch = true;

    public LootChest SelectedChest;
    void Awake()
    {
        Instance = this;
        AllChests = FindObjectsOfType<LootChest>();
        foreach (Character c in Characters)
        {
            GameObject go = Instantiate(c.PlayerPrefab, c.HomeSpawn.position, c.HomeSpawn.rotation) as GameObject;
            c.Instance = go.GetComponent<PlayerController>();
            c.Instance.LocalCharacter = c;
        }
        ChangeCharacterStart(Characters[PlayerPrefs.GetInt("SelectedChar")]);

        //SaveManager.Instance.Load();
    }
	// Use this for initialization
	void Start () {
        
    }

    public LootChest FindChestWithID(int id)
    {
        foreach(LootChest lc in AllChests)
        {
            if (lc.ID == id)
            {
                return lc;
            }
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C))
        {
            ShowCharWheel = true;
            Time.timeScale = 0.5f;
        }
        else
        {
            ShowCharWheel = false;
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Title");
        }
	}
    void ChangeCharacterStart(Character c)
    {
        LastCharacter = SelectedCharacter;
        SelectedCharacter = Characters.IndexOf(c);
        CurrentCharacter = c;
        Characters[LastCharacter].Instance.GetComponent<PlayerController>().CanPlay = false;
        Characters[SelectedCharacter].Instance.GetComponent<PlayerController>().CanPlay = true;
        Camera.main.GetComponent<SmoothFollow>().target = Characters[SelectedCharacter].Instance.transform;
        PlayerPrefs.SetInt("SelectedChar", SelectedCharacter);
    }
    void ChangeCharacter(Character c)
    {
        c.Instance.GetComponent<AI>().DoneHome = false;
        if (Vector3.Distance(Characters[SelectedCharacter].Instance.transform.position, c.Instance.transform.position) > 10)
        {
            SequenceManager.Instance.StartCoroutine("DoCharSwitch", c);
            CanShowSwitch = false;
            LastCharacter = SelectedCharacter;
            SelectedCharacter = Characters.IndexOf(c);
            CurrentCharacter = c;
            Characters[LastCharacter].Instance.GetComponent<PlayerController>().CanPlay = false;
            Characters[SelectedCharacter].Instance.GetComponent<PlayerController>().CanPlay = true;
            PlayerPrefs.SetInt("SelectedChar", SelectedCharacter);
        }
        else
        {
            LastCharacter = SelectedCharacter;
            SelectedCharacter = Characters.IndexOf(c);
            CurrentCharacter = c;
            Characters[LastCharacter].Instance.GetComponent<PlayerController>().CanPlay = false;
            Characters[SelectedCharacter].Instance.GetComponent<PlayerController>().CanPlay = true;
            PlayerPrefs.SetInt("SelectedChar", SelectedCharacter);
            Camera.main.GetComponent<SmoothFollow>().target = Characters[SelectedCharacter].Instance.transform;     
        }
    }

    void OnGUI()
    {
        if (ShowCharWheel && CanShowSwitch) 
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
    public Item FindItem(string ItemName)
    {
        foreach(Item i in AllItems)
        {
            if(i.Name==ItemName)
            {
                return i;
            }
        }
        return null;
    }
}
[System.Serializable]
public class Character
{
    public string Name;
    public Texture2D Icon;
    public GameObject PlayerPrefab;
    public PlayerController Instance;
    public Transform HomeSpawn;
}

[System.Serializable]
public class Item
{
    public string Name;
    public Texture2D Icon;
    public bool Selectable;
    public ItemInstance InstancePrefab;
}
