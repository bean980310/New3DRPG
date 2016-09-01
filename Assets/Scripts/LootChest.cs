using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootChest : MonoBehaviour {
    public int MaxItems;
    int ItemCount;
    List<Item> Items = new List<Item>();

    public int ID;

    public float Distance;

    public Color HoverColour;
    //public Color ClickColour;
    Color DefaultColour;
    bool Selected;

    public SerializableChest SChest;

    public bool HasGenerated;

    public List<Item> MyItems
    {
        get
        {
            return Items;
        }
        //set
        //{
        //    SChest.MyItems = value;
        //}
    }
    public void UpdateSC()
    {
        SChest.MyItems = MyItems;
    }
	// Use this for initialization
	void Start () {
        ItemCount = Random.Range(1, MaxItems);
        for (int i = 0; i < ItemCount; i++)
        {
            int r = Random.Range(0, CharacterManager.Instance.AllItems.Count - 1);
            Items.Add(CharacterManager.Instance.AllItems[r]);
        }
        DefaultColour = GetComponent<Renderer>().material.color;
        SChest = new SerializableChest(MyItems, ID);

        SaveManager.Instance.chests.Add(SChest);
        HasGenerated = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, CharacterManager.Instance.CurrentCharacter.Instance.transform.position) > Distance)
            OnMouseExit();

        if (Selected)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DeSelect();
            }
        }
        //if (Items.Count <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
    public void LoadItem(List<string> i)
    {
        foreach (string str in i)
        {
            MyItems.Clear();
            Items.Add(CharacterManager.Instance.FindItem(str));
        }
        UpdateSC();
    }
    void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, CharacterManager.Instance.CurrentCharacter.Instance.transform.position) < Distance)
        {
            GetComponent<Renderer>().material.color = HoverColour;
        }
    }
    void OnMouseExit()
    {
        //if (Vector3.Distance(transform.position, GameManager.Instance.CurrentCharacter.Instance.transform.position) < Distance)
            GetComponent<Renderer>().material.color = DefaultColour;
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, CharacterManager.Instance.CurrentCharacter.Instance.transform.position) < Distance)
        {
            Selected = true;
            CharacterManager.Instance.SelectedChest = this;
        }
            //GetComponent<Renderer>().material.color = ClickColour;
    }

    void DeSelect()
    {
        Selected = false;
        CharacterManager.Instance.SelectedChest = null;
    }
    //void OnMouseUp()
    //{
    //    //GetComponent<Renderer>().material.color = DefaultColour;
    //    Selected = false;
    //    GameManager.Instance.SelectedChest = null;
    //}
    //void OnGUI()
    //{

    //}
}

[System.Serializable]
public class SerializableChest
{
    [System.NonSerialized]
    List<Item> Items = new List<Item>();

    public List<Item> MyItems
    {
        get
        {
            return Items;
        }
        set
        {
            Items = value;
            _MyItemsString.Clear();

            foreach (Item i in MyItems)
            {
                Debug.Log(i.Name);
                _MyItemsString.Add(i.Name);
            }
        }
    }

    public List<string> _MyItemsString = new List<string>();
    //public List<string> MyItemsString
    //{
    //    get
    //    {
    //        _MyItemsString.Clear();

    //        foreach(Item i in MyItems)
    //        {
    //            Debug.Log(i.Name);
    //            _MyItemsString.Add(i.Name);
    //        }
    //        return _MyItemsString;
    //    }
    //}

    public int ID;

    public SerializableChest(List<Item> items, int id)
    {
        MyItems = items;
        ID = id;
    }

    //public static SerializableChest FindChestWithID(int id)
    //{
        
    //}
}