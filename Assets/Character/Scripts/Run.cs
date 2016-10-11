using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

    public float moveSpeedX;
    private float moveDirX;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        moveDirX = Input.GetAxis("Horizontal");
    }
	void FixedUpdate () {
       
        rb.velocity = new Vector2(moveDirX * moveSpeedX, rb.velocity.y);
	    
	}
}
