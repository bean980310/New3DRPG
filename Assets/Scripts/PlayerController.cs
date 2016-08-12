using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    public Animator Anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Anim.SetFloat("Speed", Input.GetAxis("Vertical")*2);
        Anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
        Anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift));
	}
}
