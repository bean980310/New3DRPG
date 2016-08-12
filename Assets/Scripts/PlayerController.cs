using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    public Animator Anim;
    public bool CanPlay;
    public Character LocalCharacter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CanPlay)
        {
            Anim.SetFloat("Speed", Input.GetAxis("Vertical") * 2);
            Anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
            Anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            Anim.SetFloat("Speed", 0);
            Anim.SetFloat("Direction", 0);
            Anim.SetBool("Running", false);
        }
	}
}
