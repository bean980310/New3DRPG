using UnityEngine;
using System.Collections;
using UnityStandardAssets;

public class HealthManager : MonoBehaviour {

    public int curHealth = 100;
    public int maxHealth = 100;

    public int curMana = 100;
    public int maxMana = 100;

    //public int curStamina = 100;
    //public int maxStamina = 100;

    int barLength = 0;

    //private PlayerController motor;
	// Use this for initialization
	void Start () {
        barLength = Screen.width / 8;
        //motor = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        AdjustCurHealth(0);
        AdjustCurMana(0);

        // Mana Control
        if (curMana >= 0)
        {
            curMana += (int)Time.deltaTime * 2;
        }

        if (curMana >= maxMana)
        {
            curMana = maxMana;
        }

        if (curMana <= 0)
        {
            curMana = 0;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AdjustCurMana(-20);
        }

        // Stamina Control

        //CharacterController controller = GetComponent<CharacterController>();

        //if (controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftControl))
        //{
            
        //}
	}

    void OnGUI()
    {
        //Icons for GUI
        GUI.Box(new Rect(5, 130, 40, 20), "HP");
        GUI.Box(new Rect(5, 150, 40, 20), "MP");
        //GUI.Box(new Rect(5, 170, 40, 20), "SP");

        //Main bars for GUI
        GUI.Box(new Rect(45, 130, barLength, 20), curHealth.ToString("0") + "/" + maxHealth);
        GUI.Box(new Rect(45, 150, barLength, 20), curMana.ToString("0") + "/" + maxMana);
        //GUI.Box(new Rect(45, 170, barLength, 20), curStamina.ToString("0") + "/" + maxStamina);
    }
    public void AdjustCurMana(int adj)
    {
        curMana += adj;
    }

    public void AdjustCurHealth(int adj)
    {
        curHealth += adj;

        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            curHealth = 0;
        }
    }
}
