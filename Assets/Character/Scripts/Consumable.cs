using UnityEngine;
using System.Collections;

public class Consumable : MonoBehaviour {

    private int count;
    private float cooldown;
    private float startTime;
    private bool healing;
    private float duration;
    private float interval;
    private float timer;

	// public Consumable?
	void Start () {
        count = Constants.CONSUMABLE_COUNT;
        cooldown = Constants.CONSUMABLE_CD;
        healing = false;
        duration = Constants.CONSUMABLE_DURATION;
        timer = 0;
	}
	
	void Update () {
        if(healing)
        {
            if (Time.time - startTime > duration)
            {
                healing = false;
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > interval)
                {
                    //add hp
                    timer = 0;
                }
            }
        }
	    else if (PlayerInput.PressedConsumable() && (Time.time - startTime > duration) && count > 0)
        {
            startTime = Time.time;
            healing = true;
            count -= 1;
        }
	}


}
