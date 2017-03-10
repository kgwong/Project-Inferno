﻿using UnityEngine;
using System.Collections;

public class IdleState : PlayerState {

    private Animator an;
    private Player play;
    private Rigidbody2D rgb;
	void Start () {
        play = GetComponent<Player>();
        an = GetComponent<Animator>();
        run = GetComponent<RunState>();
        rgb = GetComponent<Rigidbody2D>();
        roll = GetComponent<RollState>();
        sr = GetComponent<SpriteRenderer>();
        attack = GetComponent<AttackState>();
        backstep = GetComponent<BackstepState>();
        airborne = GetComponent<AirborneState>();
        name = "Idle";
	}
	
	// Update is called once per frame
	public override void Update () {
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IDLE");
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !an.GetCurrentAnimatorStateInfo(0).IsName("Attack")) //let attack animation finish
        {
            an.Play("Idle");
        }


        if (!grounded)
        {
            play.changeState(airborne);
        }

        handleInput();
    }

    public override void handleInput()
    {

        float horiz = Input.GetAxis("Horizontal");
        if (Input.GetButton("Left") || Input.GetButton("Right"))
        {
            Debug.Log("HORIZONTAL: " + horiz);
            run.setDirection(horiz);
            play.changeState(run);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rgb.AddForce(Vector2.up * play.getJump(), ForceMode2D.Impulse);
            an.Play("Jump"); 
        }
        else if(Input.GetButtonDown("Roll") && grounded && !play.getRollUsed())
        {
            roll.setStartTime(Time.time);
            play.changeState(roll);
            play.setRollCD();

        }
        else if(Input.GetButtonDown("Attack"))
        {
            play.changeState(attack);
        }
        else if(Input.GetButtonDown("Backstep") && !play.getBStepUsed())
        {
            backstep.setStartTime(Time.time);
            play.changeState(backstep);
            play.setBStepCD();

        }
    }
}