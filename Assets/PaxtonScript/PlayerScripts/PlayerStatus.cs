using UnityEngine;
using System.Collections;

public class PlayerStatus : Status {

    Health playerHealth;
    Stamina playerStamina;
    LevelLoader levelLoader;
    PlayerGUIUpdater playerGuiUpdater;
    DamageManager incomingDamage;
    
	// will have a variable for checkpoint. Access LevelLoader to load levels from here.
	void Start ()
    {
        playerHealth = new Health(100, this);
        playerStamina = new Stamina(100, this);
        incomingDamage = new DamageManager(playerHealth); 

        //set these values as you like, make sure to keep second parameter above 0.1f or will not update
        playerHealth.setRecoveryRate(1, 0.25f); //(recovery amount, amount of time between recovery)
        playerStamina.setRecoveryRate(1, 0.25f);

        levelLoader = GetComponent<LevelLoader>();
        playerGuiUpdater = GetComponent<PlayerGUIUpdater>();
	}

    new public void onDeath ()
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
        playerGuiUpdater.updateHealthBar(playerHealth.percent());
        playerGuiUpdater.updateStaminaBar(playerStamina.percent());
        playerStamina.updateStatus();
        playerHealth.updateStatus();
    }
}
