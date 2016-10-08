using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIUpdater : MonoBehaviour {

    public Health playerHealth;
    public Stamina playerStamina;


    public Image healthBar; //GUI bars are inserted manually from editor. Can't locate them otherwise.
    public Image staminaBar;

   

    // Use this for initialization
    void Start()
    {
        playerHealth = new Health(100);
        playerStamina = new Stamina(100);
      
    }
	
	
	public void updateHealthBar ()
    {
        print(playerHealth.percent());
        healthBar.fillAmount = (playerHealth.percent());
	}

    public void updateStaminaBar()
    {
        staminaBar.fillAmount = (playerStamina.percent());
    }

    //temporary code to test health subtract/add
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerHealth.add(5);
            updateHealthBar();

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.subtract(5);
            updateHealthBar();
        }
    }
}
