﻿using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {

    public float moveSpeedX;
    //private bool isRunning;

    Rigidbody2D rb;
    Animator anim;
    DirectionChecker dirCheck;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dirCheck = GetComponent<DirectionChecker>();
	}

    // Update is called once per frame

	void FixedUpdate () {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
     
            if (!anim.GetBool("roll"))
            {
                rb.velocity = new Vector2(dirCheck.getDirection() * moveSpeedX, rb.velocity.y);
            }
            
            if (!anim.GetBool("roll") && !anim.GetBool("jump"))
            { 
                anim.SetBool("run", true);
            }
        }
        else
        {
            anim.SetBool("run", false);
        }

    }
}
