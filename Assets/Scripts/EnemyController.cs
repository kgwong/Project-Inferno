using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


    public float hp = 100f;
    public float speed = 5f;
    public float damage = 20f;

    private Rigidbody2D enemyBody;
    private bool knockback = false;
    // -1 is left
    private float facing_direction = -1;
    private float knockback_timer = 0f;
    private float waitTimer = 0f;
    private bool attackWait = false;
    private float waitTime = 0.7f;
    private float knockbackTime = 0.2f;

    // Use this for initialization
    void Start ()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        if (knockback)
        {
            knockback_timer += Time.deltaTime;
        }

        if (attackWait)
        {
            waitTimer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // enemy starts to move at normal speed again
        if (knockback_timer > knockbackTime && knockback)
        {
            enemyBody.velocity = new Vector2(facing_direction * speed, 0);
            knockback = false;
            attackWait = true;
            knockback_timer = 0f;
        }

        // add force to knock enemy back and up a little if knockback == true
        if (knockback)
        {
            enemyBody.AddForce(new Vector2(0.5f * -facing_direction, 7.5f), ForceMode2D.Impulse);
        }

        else
        {
            if (attackWait)
            {
                if (waitTimer > waitTime)
                {
                    // enemy can begin moving and attacking
                    attackWait = false;
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
            // if enemy hits wall on its right/left and is facing the same direction
            if((col.gameObject.transform.position.x > transform.position.x  & facing_direction == 1) || (col.gameObject.transform.position.x < transform.position.x & facing_direction == -1))
            {
                // turn it around
                facing_direction = -facing_direction;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

        }
    }
}
