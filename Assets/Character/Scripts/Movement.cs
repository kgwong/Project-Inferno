using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float movespeed;
    public float jumpheight;
    private float moveX;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * movespeed, rb.velocity.y);
	    
	}
}
