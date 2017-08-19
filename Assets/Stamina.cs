using UnityEngine;
using System.Collections;

public class Stamina : StatusBar {

    
    int recoveryRate = 1;
    float timeBetweenRecoveries = 0.25f;
    float lastRecoveryTime = 0f;

    // Use StatusBar constructor to initialize.
    public Stamina()
    {

    }

    public Stamina(int maxStamina, PlayerStatus playrStatus) : base (maxStamina, playrStatus)
    {
        playerStatus = playrStatus;
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
        //there will be a cooldown before stamina recovers (not implemented yet).
    }

    public void setRecoveryRate(int recoveryAmount, float timeDelta)
    {
        recoveryRate = recoveryAmount;
        timeBetweenRecoveries = timeDelta;
    }

    public bool isRecovering()
    {
        return recoveryRate > 0 && timeBetweenRecoveries >= 0.1f && getRemaining() < getMax();
    }

    public void updateStamina()
    {
        if (isRecovering())
        {
            if (Time.time - lastRecoveryTime > timeBetweenRecoveries)
            {
                lastRecoveryTime = Time.time;
                add(recoveryRate);
                print(getRemaining());
            }
        }

    }


}
