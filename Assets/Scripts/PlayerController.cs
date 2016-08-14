using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    public Animator Anim;
    public bool CanPlay;
    public Character LocalCharacter;

    public Transform Hand;
    public Transform GunSpawnPoint;

    private List<Item> _inventory = new List<Item>();

    public float v;
    public float h;

    public List<Item> Inventory
    {
        get
        {
            return _inventory;
        }
        set
        {
            _inventory = value;
        }
    }

    private Item _inhand;
    public Item InHand
    {
        get
        {
            return _inhand;
        }
        set
        {
            _inhand = value;
            Destroy(InHandInstance);
            if (value != null)
            {
                InHandInstance = Instantiate(value.InstancePrefab.gameObject, Hand.position, Hand.rotation) as GameObject;
                InHandInstance.transform.parent = Hand;
            }
            if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 0)
            {
                SaveManager.Instance.p1_Hand = InHand;
            }
            if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 1)
            {
                SaveManager.Instance.p2_Hand = InHand;
            }
            if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 2)
            {
                SaveManager.Instance.p3_Hand = InHand;
            }
        }
    }

    private GameObject InHandInstance;
    // Use this for initialization
    void Start () {
        //SaveManager.Instance.SaveObj.Add(InHand);
        //SaveManager.Instance.SaveObj.Add(Inventory);
        if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 0)
        {
            SaveManager.Instance.P1_Inventory = Inventory;
        }
        if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 1)
        {
            SaveManager.Instance.P2_Inventory = Inventory;
        }
        if (GameManager.Instance.Characters.IndexOf(LocalCharacter) == 2)
        {
            SaveManager.Instance.P3_Inventory = Inventory;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (CanPlay)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            Anim.SetFloat("Speed", v * 2);
            Anim.SetFloat("Direction", h);
            Anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
            Anim.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));
            Anim.SetBool("Jumping", Input.GetKey(KeyCode.Space));
        }
        else
        {
            Anim.SetFloat("Speed", v);
            Anim.SetFloat("Direction", h);
            Anim.SetBool("Running", false);
            Anim.SetBool("Jumping", false);
        }
	}
}
