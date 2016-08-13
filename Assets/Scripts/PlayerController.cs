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
            InHandInstance = Instantiate(value.InstancePrefab.gameObject, Hand.position, Hand.rotation) as GameObject;
            InHandInstance.transform.parent = Hand;
        }
    }

    private GameObject InHandInstance;
    // Use this for initialization
    void Start () {
	
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
        }
	}
}
