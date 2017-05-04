using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {

    Health playerHealth;
    Stamina playerStamina;
	// Use this for initialization
	void Start ()
    {
        playerHealth = GetComponent<Health>();
        playerStamina = GetComponent<Stamina>();

	}

    public void death ()
    {
        //respawn, reset hp/stamina, etc.
        playerHealth.add(playerHealth.getMaxHealth());
        playerStamina.add(playerStamina.getMaxStamina());
    }
	
	// Update is called once per frame
}
