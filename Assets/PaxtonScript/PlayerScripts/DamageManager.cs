using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour {

    Rigidbody2D collisionBox;
    Health health;
	// Generalized Damage manager for both player and monster
    public DamageManager()
    {

    }

    public DamageManager(Health health)
    {
        this.health = health;
    }

	void Start()
    {
        collisionBox = GetComponent<Rigidbody2D>();
	}

    void damageHealth(int damage)
    {
        health.subtract(damage);
    }

    void detectProximityDamage(Collision collision)
    {
        //detect touch damage
    }

    void detectAttackDamage(Collision attackCollider)
    {
        //detect attack damage
    }



}
