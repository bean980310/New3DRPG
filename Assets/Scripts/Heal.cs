using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

	void OntriggerEnter(Collider col)
    {
        HealthManager manager = GameObject.Find("GameManager").GetComponent<HealthManager>();
        manager.AdjustCurHealth(20);
        Destroy(gameObject);
    }
}
