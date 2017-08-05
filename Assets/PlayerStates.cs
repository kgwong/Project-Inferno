using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {

    Health playerHealth;
    Stamina playerStamina;
    LevelLoader levelLoader;
    PlayerGUIUpdater guiUpdater;
    
	// will have a variable for checkpoint. Access LevelLoader to load levels from here.
	void Start ()
    {
        playerHealth = new Health(100, this);
        playerStamina = new Stamina(100);

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
            guiUpdater.updateHealthBar(playerHealth.percent());

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.subtract(5);
            guiUpdater.updateHealthBar(playerHealth.percent());
        }
    }
}
