using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

    private int current;
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

<<<<<<< HEAD
=======
    public void depleteStatus()
    {
        current = 0;
    }

>>>>>>> Paxton
    public void subtract(int amount)
    {
        if (current - amount >= 0)
        {
            current -= amount;
        }
        else
        {
<<<<<<< HEAD
            current = 0;
=======
            depleteStatus();
>>>>>>> Paxton
            print("status depleted");
        }
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
