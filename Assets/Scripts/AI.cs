using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
    public PlayerController Controller;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Controller.CanPlay)
        {
            transform.LookAt(Controller.LocalCharacter.HomeSpawn);
            Controller.v = 1;
        }
	}
}
