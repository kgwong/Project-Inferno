using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

    public PlayerStatus playerStatus;
    protected int current = 100;
    protected int max = 100;

    
    int recoveryAmount = 0;
    float minSecondsBetweenRecoveries = 0.1f;
    float secondsBetweenRecoveries = 0.0f;
    float lastRecoveryTime = 0f;

    public StatusBar()
    {

    }
    // Use this for initialization
    public StatusBar(int maxed, PlayerStatus playerStatus)
    {
        max = maxed;
        current = max;
        this.playerStatus = playerStatus;
    }
	
	// Update is called once per frame
    public void reset()
    {
        current = max;
    }

    //turned depleteStatus and subtract into virtual functions.
    //Health and stamina have different effects when depleted.
    public void depleteStatus()
    {
    }

    public void subtract(int amount)
    {
    }

    public void add(int amount)
    {
        if (amount + current <= max)
        {
            current += amount;
        }
        else
        {
            current = max;
        }

    }

    public int getRemaining()
    {
        return current;
    }

    public int getMax()
    {
        return max;
    }

    public float percent()
    {
        //between 0 and 1
        return (float)current / max;
    }

    public void setRecoveryRate(int recoveryAmount, float timeDeltaSeconds)
    {
        if (recoveryAmount < minSecondsBetweenRecoveries)
        {
            secondsBetweenRecoveries = minSecondsBetweenRecoveries;
        }
        else
        {
            this.recoveryAmount = recoveryAmount;
            secondsBetweenRecoveries = timeDeltaSeconds;
        }
    }

    public bool isRecovering()
    {
        return recoveryAmount > 0  && getRemaining() < getMax();
    }

    public void updateStatus()
    {
        
        if (isRecovering())
        {
            if (Time.time - lastRecoveryTime > secondsBetweenRecoveries)
            {
                lastRecoveryTime = Time.time;
                add(recoveryAmount);  
            }
        }

    }

}
