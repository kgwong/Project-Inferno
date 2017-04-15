using UnityEngine;
using System.Collections;

public class FollowingEnemyController : MonoBehaviour {
    public float hp = 100f;
    public float speed = 1f;
    public float damage = 50f;

    private GameObject player;
    private Rigidbody2D self;
    private float distance;
    private bool knockback;
    private bool wait;
    private Rigidbody2D projectile;
    private Transform weapon;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        self = gameObject.GetComponent<Rigidbody2D>();
        weapon = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        distance = Vector2.Distance(player.transform.position, transform.transform.position);

        // if player is close enough face the player
        if (distance < 10)
        {
            if (transform.position.x < player.transform.position.x & transform.localScale.x < 0 || transform.position.x > player.transform.position.x & transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.1f);
        }

        if (distance < 1)
        {
            weapon.transform.localScale = new Vector2(10, 10);
        }
    }
    

    void attack()
    {
        weapon.transform.localScale = new Vector2(10, 10);
        //weapon.transform.Rotate(Vector3.right * 1);
    }
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
