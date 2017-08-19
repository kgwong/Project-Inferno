using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

    public PlayerStatus playerStatus;
    public int current = 100;
    private int max = 100;

    public StatusBar()
    {

    }
    // Use this for initialization
    public StatusBar(int maxed, PlayerStatus playrStatus)
    {
        max = maxed;
        current = max;
        playerStatus = playrStatus;
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

}
