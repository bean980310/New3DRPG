using UnityEngine;
using System.Collections;
using System;

public class GUIManager : MonoBehaviour {

    public int InventoryColumns = 7;
    public int InventoryRows = 6;
    public int ButtonWidth = 32;
    public int ButtonHeight = 32;
    public int ButtonOffset = 5;
    int _inventoryID = 0;
    int _chestID = 1;
    Rect InventoryRect;
    Rect ChestRect;
    public bool ShowInventory;
	// Use this for initialization
	void Start () {
        InventoryRect = new Rect(0, 0, (5 + ButtonWidth) * InventoryColumns, (5 + ButtonHeight) * InventoryRows);
        ChestRect = new Rect(0, 0, (5 + ButtonWidth) * InventoryColumns, (5 + ButtonHeight) * InventoryRows);
    }
	
	// Update is called once per frame
	void Update () {      
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory = !ShowInventory;
        }
        
	}

    void OnGUI()
    {
        if (ShowInventory)
        {
            InventoryRect = GUI.Window(_inventoryID, InventoryRect, InventoryWindow, "Inventory");
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (CharacterManager.Instance.SelectedChest != null)
        {
            ChestRect = GUI.Window(_chestID, ChestRect, ChestWindow, "Chest");
        }
        if (CharacterManager.Instance.CurrentCharacter.Instance.InHand != null)
        {
            GUI.Box(new Rect(Screen.width - Screen.width / 7.5f, 0, Screen.width / 7.5f, Screen.height / 8.4f), new GUIContent("Selected Item : \n" + CharacterManager.Instance.CurrentCharacter.Instance.InHand.Name));
        }
        else
        {
            GUI.Box(new Rect(Screen.width - Screen.width / 7.5f, 0, Screen.width / 7.5f, Screen.height / 8.4f), new GUIContent("Selected Item : \nNone"));
        }
        if(GUI.Button(new Rect(0, 0, 100, 40), "Save"))
        {
            SaveManager.Instance.Save();
        }
        if (GUI.Button(new Rect(100, 0, 100, 40), "Load"))
        {
            SaveManager.Instance.Load();
        }
        if (GUI.Button(new Rect(0, 200, 225, 50), "Go to title"))
        {
            Application.LoadLevel("Title");
        }
        if (CharacterManager.Instance.ShowCharWheel && CharacterManager.Instance.CanShowSwitch)
        {
            GUILayout.BeginArea(new Rect(Screen.width - 64, Screen.height - 192, 64, 192));
            foreach (Character c in CharacterManager.Instance.Characters)
            {
                if (GUILayout.Button(c.Icon, GUILayout.Width(64), GUILayout.Height(64)))
                {
                    CharacterManager.Instance.ChangeCharacter(c);
                }
            }
            GUILayout.EndArea();
        }
    }
    void InventoryWindow(int id)
    {
        int c = 0;
        int cu = 0;
        for (int x = 0; x < InventoryColumns; x++)
        {
            for (int y = 0; y < InventoryRows; y++)
            {
                if (c < CharacterManager.Instance.CurrentCharacter.Instance.Inventory.Count)
                {
                    if(GUI.Button(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu].Name)){
                        if (Event.current.button == 0)
                        {
                            if (CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu].Selectable)
                            {
                                CharacterManager.Instance.CurrentCharacter.Instance.InHand = CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu];
                            }
                        }
                        else if(Event.current.button == 1)
                        {
                            if (CharacterManager.Instance.SelectedChest != null)
                            {
                                if(CharacterManager.Instance.SelectedChest.MyItems.Count<CharacterManager.Instance.SelectedChest.MaxItems)
                                {
                                    CharacterManager.Instance.SelectedChest.MyItems.Add(CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu]);
                                    if (CharacterManager.Instance.CurrentCharacter.Instance.InHand == CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu])
                                    {
                                        CharacterManager.Instance.CurrentCharacter.Instance.InHand = null;
                                    }
                                    CharacterManager.Instance.CurrentCharacter.Instance.Inventory.Remove(CharacterManager.Instance.CurrentCharacter.Instance.Inventory[cu]);
                                }
                            }
                        }
                        CharacterManager.Instance.SelectedChest.UpdateSC();
                    }
                    cu++;
                }
                else
                {
                    GUI.Label(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), ((x + y * InventoryColumns) + 1).ToString());
                }
                c++;
            }
        }
        GUI.DragWindow();
    }
    void ChestWindow(int id)
    {
        int c = 0;
        for (int x = 0; x < InventoryColumns; x++)
        {
            for (int y = 0; y < InventoryRows; y++)
            {
                //int temp = (x + y * InventoryColumns);

                //Debug.Log(temp);
                if (c <= CharacterManager.Instance.SelectedChest.MyItems.Count-1)
                {
                    if(GUI.Button(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), CharacterManager.Instance.SelectedChest.MyItems[c].Name))
                    {
                        CharacterManager.Instance.CurrentCharacter.Instance.Inventory.Add(CharacterManager.Instance.SelectedChest.MyItems[c]);
                        CharacterManager.Instance.SelectedChest.MyItems.Remove(CharacterManager.Instance.SelectedChest.MyItems[c]);
                        CharacterManager.Instance.SelectedChest.UpdateSC();
                    }
                    c++;
                }
            }
        }
        GUI.DragWindow();
    }
}
