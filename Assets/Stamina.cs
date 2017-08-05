using UnityEngine;
using System.Collections;

public class Stamina : StatusBar {

	// Use StatusBar constructor to initialize.
    public Stamina()
    {

    }

    public Stamina(int maxStamina) : base (maxStamina)
    {
   
    }

    public bool staminaAvailable(int cost)
    {
        int remainingStamina = getRemaining();
        if (cost > remainingStamina)
        {
            depleteStatus();
            print("attack stopped: lack of stamina");
        }
        return cost <= remainingStamina;
    }

    new public void subtract(int amount)
    {
        if (current - amount > 0)
        {
            current -= amount;
        }
        else
        {
            depleteStatus();
        }
    }

    new public void depleteStatus()
    {
        current = 0;
        //there will be a cooldown before stamina recovers.
    }



}
