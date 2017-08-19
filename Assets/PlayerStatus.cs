using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    Health playerHealth;
    Stamina playerStamina;
    LevelLoader levelLoader;
    PlayerGUIUpdater guiUpdater;
    
	// will have a variable for checkpoint. Access LevelLoader to load levels from here.
	void Start ()
    {
        playerHealth = new Health(100, this);
        playerStamina = new Stamina(100, this);

        //set these values as you like, make sure to keep second parameter above 0.1f or will not update
        playerHealth.setRecoveryRate(1, 0.25f);
        playerStamina.setRecoveryRate(1, 0.25f);

        levelLoader = GetComponent<LevelLoader>();
        guiUpdater = GetComponent<PlayerGUIUpdater>();
	}

    public void onDeath ()
    {
        //respawn, reset hp/stamina, etc.
        levelLoader.loadDeathScreen();
        playerHealth.reset();
        playerStamina.reset();
    }

    //temporary testing to increase/decrease health
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerHealth.add(5);
            playerStamina.add(5);

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.subtract(5);
            playerStamina.subtract(5);
        }
        guiUpdater.updateHealthBar(playerHealth.percent());
        guiUpdater.updateStaminaBar(playerStamina.percent());
        playerStamina.updateStatus();
        playerHealth.updateStatus();
    }
}
