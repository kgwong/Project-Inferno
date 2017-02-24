using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    public float rollSpeedX;
    private bool inRoll;
    private float startTime;
    public float rollDuration;

    GroundChecker checkGround;
    BoxCollider2D colliderBox;
    Animator anim;
    Rigidbody2D rb;
    DirectionChecker dirCheck;
    ConstantForce2D rollPusher;

	void Start () {
        checkGround = GetComponent<GroundChecker>();
        colliderBox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dirCheck = GetComponent<DirectionChecker>();
        rollPusher = GetComponent<ConstantForce2D>();

        startTime = Time.time;
        inRoll = false;
	}
	
	
	void FixedUpdate () {
    

        bool touchingGround = checkGround.OnGround(colliderBox);
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (touchingGround && !inRoll)
            {
                startTime = Time.time;
                anim.SetBool("roll", true);
                anim.SetBool("run", false);
                inRoll = true;
                colliderBox.size = new Vector2(colliderBox.size.x, colliderBox.size.y /2);
                print(rb.velocity);
                rollPusher.force = new Vector2(dirCheck.getDirection() * rollSpeedX, 0);
            }
        }


        else if (inRoll && Time.time - startTime > rollDuration)
        {
            inRoll = false;
            print("roll should have ended");
            colliderBox.size = new Vector2(colliderBox.size.x, colliderBox.size.y * 2);
            rollPusher.force = new Vector2(0, 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("roll", false);

        }

            
        }
	
	
}
