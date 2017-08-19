using UnityEngine;
using System.Collections;

public class Health : StatusBar {


    public Health()
    {

    }

    public Health(int maxHealth, PlayerStatus playrStatus) : base(maxHealth, playrStatus)
    {
        playerStatus = playrStatus;
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
        playerStatus.onDeath();
        print("health depleted, dead");
    }
}
