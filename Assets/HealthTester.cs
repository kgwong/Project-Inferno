using UnityEngine;
using System.Collections;

public class HealthTester : MonoBehaviour {

    Health playerHealth;
    PlayerGUIUpdater playerGUI;
	// Use this for initialization
	void Start ()
    {
        playerHealth = GetComponent<Health>();
        playerGUI = GetComponent<PlayerGUIUpdater>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerHealth.add(5);
            playerGUI.updateHealthBar();

        }  
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.subtract(5);
            playerGUI.updateHealthBar();
        }
	}
}
