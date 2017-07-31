using UnityEngine;
using System.Collections;

public class FollowingEnemyController : MonoBehaviour {
    public float hp = 100f;
    public float speed = 1;
    public float damage = 50f;

    private GameObject player;
    private Rigidbody2D self;
    private float distance;
    private Rigidbody2D projectile;
    private bool attackWait = false;
    // -1 is left
    private int facing_direction = -1;
    private float waitTimer = 0f;
    private float timeToWait = 0.8f;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        self = gameObject.GetComponent<Rigidbody2D>();
    }


	// Update is called once per frame
    void Update()
    {
        if (attackWait)
        {
            waitTimer += Time.deltaTime;
        }

        if (waitTimer > 1f)
        {
            attackWait = false;
        }
    }

	void FixedUpdate ()
    {
        distance = transform.position.x - player.transform.position.x;
        float enemyX = transform.position.x;
        float playerX = player.transform.position.x;

        if ((distance < 10 && distance > -10) & !attackWait)
        {
            if (distance < 3 && distance > -3)
            {
                // stop in place to attack
                self.velocity = new Vector2(0, 0);
                // some code here to attack
                attackWait = true;
            }
            else
            {
                // if enemy is to the left/right of player and facing the opposite direction, turn around
                if (enemyX < playerX && facing_direction == -1 || enemyX > playerX && facing_direction == 1)
                {
                    facing_direction = -facing_direction;
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                // constantly move towards the player
                self.velocity = new Vector2(facing_direction * speed, 0);
            }            
        }

        // if enemy can't attack but is in range to follow
        else if ((distance < 10 & distance > -10) && attackWait)
        {
            if (waitTimer > timeToWait)
            {
                // same as line 55 above begin following player
                if (enemyX < playerX && facing_direction == -1 || enemyX > playerX && facing_direction == 1)
                {
                    facing_direction = -facing_direction;
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                    // continue following the player
                    self.velocity = new Vector2(facing_direction * speed, 0);

                waitTimer = 0f;
                attackWait = false;
            }
        }

    }
    

    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
