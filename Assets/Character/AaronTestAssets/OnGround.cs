using UnityEngine;
using System.Collections;

public class OnGround : MonoBehaviour {


    private float jumpBuffer;
    private int groundLayer;
    private RaycastHit2D downRay;
    private SpriteRenderer sr;
    private Animator an; 
    float rayDistance;

	void Start () {
        jumpBuffer = 0.1f;
        groundLayer = 1 << 8;
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();

	}
	
   public bool checkGrounded()
    {
        downRay = Physics2D.Raycast(sr.bounds.center + Vector3.down * sr.bounds.size.y / 2, Vector3.down, jumpBuffer, groundLayer);
        an.SetBool("OnGround", downRay.collider != null);
        return (downRay.collider != null);
    }
    
}
