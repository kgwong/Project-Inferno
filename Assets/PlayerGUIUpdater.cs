using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIUpdater : MonoBehaviour {

    private Health playerHealth;
    private Stamina playerStamina;


    public Image healthBar; //GUI bars are inserted manually from editor. Can't locate them otherwise.
    public Image staminaBar;

   

    // Use this for initialization
    void Start()
    {
        playerHealth = new Health(100);
        playerStamina = new Stamina(100);
        

      
    }
	
	// Update is called once per frame
	public void updateHealthBar ()
    {
        print(playerHealth.percent());
        healthBar.fillAmount = (playerHealth.percent());
	}

    public void updateStaminaBar()
    {
        staminaBar.fillAmount = (playerStamina.percent());
    }
}
