using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

    public int current;
    private int max;

    public StatusBar()
    {

    }
    // Use this for initialization
    public StatusBar(int maxed)
    {
        max = maxed;
        current = max;
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
