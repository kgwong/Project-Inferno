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
        playerHealth = GetComponent<Health>();
      
    }
	
	// Update is called once per frame
	public void updateHealthBar ()
    {
        print(playerHealth.healthPercent());
        healthBar.fillAmount = (playerHealth.healthPercent());
	}

    public void updateStaminaBar()
    {
        staminaBar.fillAmount = (playerStamina.staminaPercent());
    }
}
