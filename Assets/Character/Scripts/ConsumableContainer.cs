using UnityEngine;
using System.Collections;

public class ConsumableContainer : MonoBehaviour {

    Consumable c;
    private double lastConsume;
    private int count;
	
	// Update is called once per frame
	void Update () {
	}

    void useConsumable()
    {
        if (count > 0 && Time.time - lastConsume > c.cooldown)
        {
            c.consume();
            count--;
            lastConsume = Time.time;
        }
    }
}
