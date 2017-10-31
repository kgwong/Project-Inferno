using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIUpdater : MonoBehaviour {

    public Image healthBar; //GUI bars are inserted manually from editor. Can't locate them otherwise.
    public Image staminaBar;

    // Use this for initialization
    void Start()
    {
      
    }
	
	public void updateHealthBar (float percent)
    {
        healthBar.fillAmount = percent;
	}

    public void updateStaminaBar(float percent)
    {
        staminaBar.fillAmount = percent;
    }

}
