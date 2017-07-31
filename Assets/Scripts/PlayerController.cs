using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float hp = 100f;
    public float damage = 10f;
    public float speed = 5f;

    //private float facingDirection = 1;
    private Rigidbody2D playerBody;
    private bool knockback = false;
    private float knockback_timer = 0f;
    private float waitTimer = 0f;
    private bool wait = false;
    private bool canMove = true;
    private float moveX;
    private float moveY;

    // Use this for initialization
    void Start () {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

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
        if (canMove == true)
        {
            moveX = Input.GetAxis("Horizontal");

            moveY = Input.GetAxis("Vertical");
            playerBody.velocity = (new Vector2(moveX * speed, moveY * 5));
        }

        else
        {
            if (Input.GetButtonDown("Fire1") == true)
            {
                playerBody.velocity = new Vector2();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //knockback = true;
            //canMove = false;
            //hp -= col.gameObject.GetComponent<EnemyController>().damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    //void OnTriggerEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Projectile")
    //    {
    //        Destroy(col.gameObject);
    //    }
    //}
}
