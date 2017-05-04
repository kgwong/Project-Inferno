using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {

    public int maxStamina;
    private int currentStamina;
	// Use this for initialization
	void Start ()
    {
        currentStamina = maxStamina;
	    
	}

    public void add(int amount)
    {
        if (amount + currentStamina <= maxStamina)
        {
            currentStamina += amount;
        }
        else
        {
            currentStamina = maxStamina;
        }
    }

    public void subtract(int amount)
    {
        if (currentStamina - amount >= 0)
        {
            currentStamina -= amount;
        }
        else
        {
            currentStamina = 0;
            print("out of stamina");
        }
    }

    public int getMaxStamina()
    {
        return maxStamina;
    }

    public int getCurrentStamina()
    {
        return currentStamina;
    }
	// Update is called once per frame
    public float staminaPercent()
    {
        return currentStamina / maxStamina;
    }
}
