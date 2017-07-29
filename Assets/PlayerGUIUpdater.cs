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
        // lol
        //playerHealth = new Health(100); 
        //playerStamina = new Stamina(100);
        //
        playerHealth = GetComponent<Health>();
        playerStamina = GetComponent<Stamina>();
      
    }
	
	// Update is called once per frame
	public void updateHealthBar ()
    {
        //print(playerHealth.percent()); // spamming my output nty
        healthBar.fillAmount = (playerHealth.percent());
	}

    public void updateStaminaBar()
    {
        staminaBar.fillAmount = (playerStamina.percent());
    }

    //temporary code to test health subtract/add
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    playerHealth.add(5);
        //    updateHealthBar();

        //}
        //else if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    playerHealth.subtract(5);
        //    updateHealthBar();
        //}
        
        // sync with changes to the bars

        updateHealthBar();
        updateStaminaBar();
    }
}
