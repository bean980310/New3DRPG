using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public WeaponType TypeOfWeapon;

    public GameObject Sparks;
    Transform SpawnPoint;
	// Use this for initialization
	void Start () {
        if (TypeOfWeapon == WeaponType.Gun)
        {
            SpawnPoint = CharacterManager.Instance.CurrentCharacter.Instance.GunSpawnPoint;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (TypeOfWeapon == WeaponType.Gun)
        {
            if (Input.GetMouseButtonDown(0)||Input.GetKey(KeyCode.Z))
            {
                Fire();
            }
        }
	}
    void Fire()
    {
        Debug.Log("Fire");
        RaycastHit hit;
        if(Physics.Raycast(SpawnPoint.position, SpawnPoint.forward,out hit, 800))
        {
            Instantiate(Sparks, hit.point, Quaternion.FromToRotation(Vector3.forward,hit.normal));
        }
    }
}

public enum WeaponType
{
    Gun,
    Sword,
    Bow
}
