using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    private int currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;  
	}
	
	// Update is called once per frame
	public void subtract(int damage)
    {
        if (currentHealth - damage >= 0)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0;
            print("dead");
        }
    }

    public void add(int amount)
    {
        if (amount + currentHealth <= maxHealth)
        {
            currentHealth += amount;  
        }
        else
        {
            currentHealth = maxHealth;
        }

    }

    public int getRemainingHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public float healthPercent()
    {
        //between 0 and 1
        return (float)currentHealth / maxHealth;
    }
}
