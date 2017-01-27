using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    public float rollSpeedX;
    private bool inRoll;
    private float startTime;
    public float rollDuration;

    GroundChecker checkGround;
    Collider2D colliderBox;
    Animator anim;
    Rigidbody2D rb;
    DirectionChecker dirCheck;
    ConstantForce2D rollPusher;

	void Start () {
        checkGround = GetComponent<GroundChecker>();
        colliderBox = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dirCheck = GetComponent<DirectionChecker>();
        rollPusher = GetComponent<ConstantForce2D>();

        startTime = Time.time;
        inRoll = false;
	}
	
	
	void FixedUpdate () {
    

        bool touchingGround = checkGround.isGrounded();
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (touchingGround && !inRoll)
            {
                startTime = Time.time;
                anim.SetBool("roll", true);
                inRoll = true;
                colliderBox.offset.Set(0, colliderBox.bounds.extents.y / 2);
                print(rb.velocity);
                rollPusher.force = new Vector2(dirCheck.getDirection() * rollSpeedX, 0);
            }
        }


        else if (inRoll && Time.time - startTime > rollDuration)
        {
            inRoll = false;
            print("roll should have ended");
            anim.SetBool("roll", false);
            rollPusher.force = new Vector2(0, 0);
        }

            
        }
	
	
}
