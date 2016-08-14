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
        Debug.Log(path);
    }
    public void Load()
    {

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
