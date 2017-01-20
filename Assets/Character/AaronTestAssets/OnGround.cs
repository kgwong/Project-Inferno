using UnityEngine;
using System.Collections;

public class OnGround : MonoBehaviour {


    private float jumpBuffer;
    private int groundLayer;
    private RaycastHit2D downRay;
    private SpriteRenderer sr;
    private Rigidbody2D rb; //don't need?
    private Animator an; 
    float rayDistance;

	void Start () {
        jumpBuffer = 0.1f;
        groundLayer = 1 << 8;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

	}
	
	void Update () {
        // checkGrounded();
        //Debug.Log(an.GetBool("OnGround"));

    }

    public bool isGrounded()
    {

        return an.GetBool("OnGround");
    }

   public bool checkGrounded()
    {
        downRay = Physics2D.Raycast(sr.bounds.center + Vector3.down * sr.bounds.size.y / 2, Vector3.down, jumpBuffer, groundLayer);
        an.SetBool("OnGround", downRay.collider != null);
        return (downRay.collider != null);
    }
    
}
