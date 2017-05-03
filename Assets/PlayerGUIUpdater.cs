using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIUpdater : MonoBehaviour {

    private Health playerHealth;
    public Image healthBar;

    

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
}
