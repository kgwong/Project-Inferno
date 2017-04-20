using UnityEngine;
using System.Collections;

public class FlyingEnemyController : MonoBehaviour {
    public float hp = 100f;
    public float speed = 10;
    public float damage = 50f;

    private GameObject player;
    private Rigidbody2D self;
    private float distance;
    private float height;
    private bool attackEnable = true;
    private bool attackWait = false;
    private float waitTimer = 0f;
    private int facing_direction = -1;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        self = gameObject.GetComponent<Rigidbody2D>();
        height = transform.position.y;
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (attackWait == true)
        {
            waitTimer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        distance = transform.position.x - player.transform.position.x;

        if (attackWait == true & transform.position.y >= height)
        {
            print(0);
            if (waitTimer > 1)
            {
                attackWait = false;
                waitTimer = 0f;
            }
            else
            {
                self.velocity = new Vector2(speed * facing_direction, 0);
            }
        }

        else if (attackWait == false & (distance < 3 & distance > -3))
        {
            print(1);
            self.velocity = new Vector2(speed * facing_direction, -15);
        }

        else if (attackWait == false & (distance > 3 || distance < -3) & transform.position.y >= height)
        {
            print(11);
            self.velocity = new Vector2(speed * facing_direction, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            facing_direction = -facing_direction;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Player")
        {
            self.velocity = new Vector2(0, 10);
            attackWait = true;
        }

    }
}
