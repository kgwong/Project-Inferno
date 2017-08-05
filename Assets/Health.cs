using UnityEngine;
using System.Collections;

public class Health : StatusBar {

    PlayerStates playerStates;

    public Health()
    {

    }

    public Health(int maxHealth, PlayerStates playrStates) : base(maxHealth)
    {
        playerStates = playrStates;
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
        playerStates.onDeath();
        print("health depleted, dead");
    }
}
