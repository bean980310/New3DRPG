﻿using UnityEngine;
using System.Collections;

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
        if (GameManager.Instance.SelectedChest != null)
        {
            ChestRect = GUI.Window(_chestID, ChestRect, ChestWindow, "Chest");
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
                if (c < GameManager.Instance.CurrentCharacter.Instance.Inventory.Count)
                {
                    if(GUI.Button(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), GameManager.Instance.CurrentCharacter.Instance.Inventory[cu].Name)){
                        if (GameManager.Instance.CurrentCharacter.Instance.Inventory[cu].Selectable)
                        {
                            GameManager.Instance.CurrentCharacter.Instance.InHand = GameManager.Instance.CurrentCharacter.Instance.Inventory[cu];
                        }         
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
                if (c <= GameManager.Instance.SelectedChest.MyItems.Count-1)
                {
                    if(GUI.Button(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), GameManager.Instance.SelectedChest.MyItems[c].Name))
                    {
                        GameManager.Instance.CurrentCharacter.Instance.Inventory.Add(GameManager.Instance.SelectedChest.MyItems[c]);
                        GameManager.Instance.SelectedChest.MyItems.Remove(GameManager.Instance.SelectedChest.MyItems[c]);
                    }
                    c++;
                }
            }
        }
        GUI.DragWindow();
    }
}
