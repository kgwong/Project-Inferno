﻿using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {


    public float move_speed = 3f;
    public float jump_power = 8f;
    public float roll_speed = 5f;
    public float roll_time = 0.5f;


    private Animator animator;
    private Rigidbody2D rb;
    private int directionFacing = 1;
    //private ArrayList lockStates = new ArrayList();
    private AnimatorStateInfo stateInfo;
    private Vector3 scale;
    private float timer;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private float heightDifference = (float)0.65;
	

	void Start () {


        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // lockStates.Add();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        scale = transform.localScale;
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate () {
        bc.size = sr.bounds.size;
        if (!animator.GetBool("Rolling"))
        {
            //horizontal movement
            float horizontal = Input.GetAxis("Horizontal");
            rb.AddForce(Vector2.right * horizontal * move_speed, ForceMode2D.Impulse);



            if (animator.GetBool("OnGround"))
                {
                    if (horizontal != 0)
                    {
                        animator.Play("Walk");
                        Flip(horizontal);
                    }

                    else
                    {
                        animator.Play("Idle");
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        animator.SetBool("OnGround", false);
                        animator.Play("Jump");
                        rb.AddForce(Vector2.up * jump_power, ForceMode2D.Impulse);
                        //bc.size += Vector2.up * heightDifference;


                }

                if (Input.GetKeyDown(KeyCode.X))
                    {
                        animator.SetBool("OnGround", false);
                        animator.SetBool("Rolling", true);
                        timer = Time.time;
                    }

                }
            }
        else 
        {
            float timePassed = Time.time-timer;
            if (timePassed < roll_time)
            {
                animator.Play("Roll");
                Flip(directionFacing);
                rb.AddForce(new Vector2(roll_speed * directionFacing, 0), ForceMode2D.Impulse);
            }
            else
            {
                animator.SetBool("OnGround", true);
                animator.SetBool("Rolling", false);
            }
        }
    }

    void Flip(float horizontal)
    {
        if ((directionFacing == 1 && horizontal < 0) || (directionFacing == -1 && horizontal > 0))
        {
            scale.x *= -1;
            transform.localScale = scale;

            directionFacing = (int)(horizontal / Mathf.Abs(horizontal));

        }   
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        //(queue input)
        //maybe add a bit of space above the ground to be considered OnGround
        //attempting to jump slightly before you actually hit the ground and failing feels bad
        if (coll.gameObject.tag == "Platform")
        {
            Vector3 contactPoint = coll.contacts[0].point;
            float bottomPlayer = transform.position.y - (sr.bounds.size.y / 2) + (float)0.01;
           print("bottom of player: " + bottomPlayer);
            //print("contact point" + contactPoint);

            if (contactPoint.y < bottomPlayer)
            {
                print(bc.transform.position);
                print("HIT GROUND");
                animator.SetBool("OnGround", true);
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform")
        {
            animator.SetBool("OnGround", false);
        }
    }

    
}
