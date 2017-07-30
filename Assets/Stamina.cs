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
<<<<<<< HEAD
=======

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



>>>>>>> Paxton
}
