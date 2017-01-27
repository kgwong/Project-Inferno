using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

    public float moveSpeedX;
    private float moveDirX;
    private bool isRunning;

    Rigidbody2D rb;
    Animator anim;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame

	void FixedUpdate () {

        moveDirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirX * moveSpeedX, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.x) > 1f && anim.GetBool("roll") == false)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (anim.GetBool("jump") == false)
        {
            anim.SetBool("run", isRunning);
        }
    }
}
