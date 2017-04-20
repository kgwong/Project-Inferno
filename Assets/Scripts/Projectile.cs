using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float damage = 25f;
    public float speed = 15f;

    private Rigidbody2D self;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        self = gameObject.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());

    }

    // Update is called once per frame
    void Update ()
    {
        self.velocity = new Vector2(-speed, 0);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().hp -= damage;
            Destroy(gameObject);
        }
        
        else if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
