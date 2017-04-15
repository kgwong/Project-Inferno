using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


    public float hp = 100f;
    public float speed = 5f;
    public float damage = 20f;

    private Rigidbody2D enemyBody;
    private bool knockback = false;
    private float facing_direction = -1;
    private float knockback_timer = 0f;
    private float waitTimer = 0f;
    private bool wait = false;

	// Use this for initialization
	void Start ()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (knockback == true)
        {
            knockback_timer += Time.deltaTime;
        }
        if (wait == true)
        {
            waitTimer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // enemy starts to move at normal speed again
        if (knockback_timer > 0.2f & knockback == true)
        {
            enemyBody.velocity = new Vector2(facing_direction * speed, 0);
            knockback = false;
            wait = true;
            knockback_timer = 0f;
        }

        // add force to knock enemy back and up a little if knockback == true
        if (knockback == true)
        {
            enemyBody.AddForce(new Vector2(0.5f * -facing_direction, 7.5f), ForceMode2D.Impulse);
        }

        // 
        else
        {
            if (wait == true)
            {
                if (waitTimer > 0.7f)
                {
                    wait = false;
                    waitTimer = 0f;
                    enemyBody.velocity = new Vector2(facing_direction * speed, 0);
                }
                else
                {
                    enemyBody.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                enemyBody.velocity = new Vector2(facing_direction * speed, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            knockback = true;
            hp -= col.gameObject.GetComponent<PlayerController>().damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        else if (col.gameObject.tag == "Wall")
        {
            facing_direction = -facing_direction;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
