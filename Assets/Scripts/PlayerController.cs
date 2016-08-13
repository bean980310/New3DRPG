using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
    public Animator Anim;
    public bool CanPlay;
    public Character LocalCharacter;

    public float v;
    public float h;
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
        }
        else
        {
            Anim.SetFloat("Speed", v);
            Anim.SetFloat("Direction", h);
            Anim.SetBool("Running", false);
        }
	}
}
