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

    public void Ondeath ()
    {
        //respawn, reset hp/stamina, etc.
        playerHealth.reset();
        playerStamina.reset();
    }
	
	// Update is called once per frame
}
