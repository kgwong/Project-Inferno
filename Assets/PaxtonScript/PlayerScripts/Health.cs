using UnityEngine;
using System.Collections;

public class Health : StatusBar {


    public Health()
    {

    }

    public Health(int maxHealth, Status status) : base(maxHealth, status)
    {
        this.status = status;
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
        status.onDeath();
        print("health depleted, dead");
    }
}
