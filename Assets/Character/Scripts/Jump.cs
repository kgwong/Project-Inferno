using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    
    public float moveSpeedY;
    private bool inJump; 
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!inJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (rb.velocity.y == 0f)
                {
                    inJump = true;
                }
                

            }
        }
	}

    void FixedUpdate()
    {
        if (inJump)
        {
            rb.velocity = (new Vector2(rb.velocity.x, moveSpeedY));
            inJump = false;
        }
    }
}
