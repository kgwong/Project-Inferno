using UnityEngine;
using System.Collections;

public class MonsterStatus : Status {

    Health monsterHealth;
	// Use this for initialization
	void Start ()
    {
        monsterHealth = new Health(30, this);
	}
	
    new void onDeath()
    {
        print("killed monster");
        Destroy(gameObject);
    }
    
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
