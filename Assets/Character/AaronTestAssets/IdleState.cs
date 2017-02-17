using UnityEngine;
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
        //airborne = GetComponent<AirborneState>();
        name = "Idle";
	}
	
	// Update is called once per frame
	public override void Update () {
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IDLE");
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Attack")) //let attack animation finish
        {
            an.Play("Idle");
        }


        //if (!grounded)
        //{
        //    play.changeState(airborne);
        //}

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
            Debug.Log("JUMP");
            rgb.AddForce(Vector2.up * play.getJump(), ForceMode2D.Impulse);
            //an.Play("Jump"); gets overwritten by other state's animations
        }
        else if(Input.GetButtonDown("Roll") && grounded)
        {
            roll.setStartTime(Time.time);
            play.changeState(roll);
        }
        else if(Input.GetButtonDown("Attack"))
        {
            play.changeState(attack);
        }
    }
}
