using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
    public int InventoryColumns = 7;
    public int InventoryRows = 6;
    public int ButtonWidth = 32;
    public int ButtonHeight = 32;
    public int ButtonOffset = 5;
    int _inventoryID = 0;
    Rect InventoryRect;
    public bool ShowInventory;
	// Use this for initialization
	void Start () {
        InventoryRect = new Rect(0, 0, (5 + ButtonWidth) * InventoryColumns, (5 + ButtonHeight) * InventoryRows);
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
        if(ShowInventory)
        {
            InventoryRect = GUI.Window(_inventoryID, InventoryRect, InventoryWindow, "Inventory");
        }
    }
    void InventoryWindow(int id)
    {
        for(int x = 0; x < InventoryColumns; x++)
        {
            for(int y = 0; y < InventoryRows; y++)
            {
                GUI.Button(new Rect(ButtonOffset + (ButtonWidth * x), ButtonOffset + (ButtonHeight * y), ButtonWidth, ButtonHeight), ((x + y * InventoryColumns) + 1).ToString());
            }
        }
        GUI.DragWindow();
    }
}
