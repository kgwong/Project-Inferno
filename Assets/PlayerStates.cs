using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {

    Health playerHealth;
    Stamina playerStamina;
    LevelLoader levelLoader;
	// will have a variable for checkpoint. Access LevelLoader to load levels from here.
	void Start ()
    {
        playerHealth = GetComponent<Health>();
        playerStamina = GetComponent<Stamina>();

	}

    public void Ondeath ()
    {
        //respawn, reset hp/stamina, etc.
        levelLoader.loadDeathScreen();
        playerHealth.reset();
        playerStamina.reset();
    }
	
	// Update is called once per frame
}
