using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {
    public List<object> SaveObj = new List<object>();

    public Item p1_Hand;
    public Item p2_Hand;
    public Item p3_Hand;

    public List<Item> P1_Inventory = new List<Item>();
    public List<Item> P2_Inventory = new List<Item>();
    public List<Item> P3_Inventory = new List<Item>();

    public List<SerializableChest> chests = new List<SerializableChest>();

    string path = @"\Save.tgtayt";

    public static SaveManager Instance;
    void Awake()
    {
        Instance = this;
        StartCoroutine("Load");
        //Load();
    }
	public void Save()
    {
        SaveObj.Add(p1_Hand.Name);
        SaveObj.Add(p2_Hand.Name);
        SaveObj.Add(p3_Hand.Name);

        List<string> P1_string = new List<string>();
        foreach(Item i in P1_Inventory)
        {
            P1_string.Add(i.Name);
        }
        List<string> P2_string = new List<string>();
        foreach (Item i in P2_Inventory)
        {
            P2_string.Add(i.Name);
        }
        List<string> P3_string = new List<string>();
        foreach (Item i in P3_Inventory)
        {
            P3_string.Add(i.Name);
        }

        SaveObj.Add(P1_string);
        SaveObj.Add(P2_string);
        SaveObj.Add(P3_string);
        SaveObj.Add(chests);
        byte[] b = Serialize();
        File.WriteAllBytes(Application.persistentDataPath + path, b);
        Debug.Log(Application.persistentDataPath + path);
    }
    public IEnumerator Load()
    {
        byte[] b = File.ReadAllBytes(Application.persistentDataPath + path);
        List<object> o = DeSerialize(b);
        p1_Hand = GameManager.Instance.FindItem((string)o[0]);
        p2_Hand = GameManager.Instance.FindItem((string)o[1]);
        p3_Hand = GameManager.Instance.FindItem((string)o[2]);
        List<string> P1_string = new List<string>();
        P1_string = (List<string>)o[3];
        List<Item> p1_i = new List<Item>();
        foreach (string str in P1_string)
        {
            p1_i.Add(GameManager.Instance.FindItem(str));
        }
        P1_Inventory = p1_i;
        List<string> P2_string = new List<string>();
        P2_string = (List<string>)o[4];
        List<Item> p2_i = new List<Item>();
        foreach (string str in P2_string)
        {
            p2_i.Add(GameManager.Instance.FindItem(str));
        }
        P2_Inventory = p2_i;
        List<string> P3_string = new List<string>();
        P3_string = (List<string>)o[5];
        List<Item> p3_i = new List<Item>();
        foreach (string str in P3_string)
        {
            p3_i.Add(GameManager.Instance.FindItem(str));
        }
        P3_Inventory = p3_i;

        chests = (List<SerializableChest>)o[6];

        foreach(SerializableChest sc in chests)
        {
            //Debug.Log(sc.ID);
            Debug.Log(GameManager.Instance.FindChestWithID(sc.ID).HasGenerated);
            while (GameManager.Instance.FindChestWithID(sc.ID).HasGenerated)
            {
                //Debug.Log(GameManager.Instance.FindChestWithID(sc.ID).HasGenerated);
                yield return new WaitForEndOfFrame();
                //Debug.Log(GameManager.Instance.FindChestWithID(sc.ID).HasGenerated);
            }
            GameManager.Instance.FindChestWithID(sc.ID).LoadItem(sc._MyItemsString);
        }
        GameManager.Instance.Characters[0].Instance.Inventory = P1_Inventory;
        GameManager.Instance.Characters[0].Instance.InHand = p1_Hand;

        GameManager.Instance.Characters[1].Instance.Inventory = P2_Inventory;
        GameManager.Instance.Characters[1].Instance.InHand = p2_Hand;

        GameManager.Instance.Characters[2].Instance.Inventory = P3_Inventory;
        GameManager.Instance.Characters[2].Instance.InHand = p3_Hand;

        StopCoroutine("Load");
    }
    byte[] Serialize()
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, SaveObj);
        return ms.ToArray();
    }
    List<object> DeSerialize(byte[] b)
    {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        ms.Write(b, 0, b.Length);
        ms.Seek(0, SeekOrigin.Begin);
        List<object> obj = (List<object>)bf.Deserialize(ms);
        return obj;
    }
}
