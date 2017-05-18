using UnityEngine;
using System.Collections;

public class IdleState : PlayerStates {

    private Animator an;
    private Player play;
    private Rigidbody2D rgb;
	void Start () {
        play = GetComponent<Player>();
        an = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        name = "Idle";
	}
	
	// Update is called once per frame
	public override void Update () {
	}

    public override void ComponentUpdate()
    {
        facing = play.getRun().getFacing();
        Debug.Log("IDLE");
        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !an.GetCurrentAnimatorStateInfo(0).IsName("Attack")) //let attack animation finish
        {
            an.Play("Idle");
        }


        if (!grounded)
        {
            play.changeState(StateEnums.AirborneState);
        }

        handleInput();
    }

    public override void handleInput()
    {

        float horiz = Input.GetAxis("Horizontal");
        if (Input.GetButton("Left") || Input.GetButton("Right"))
        {
            Debug.Log("HORIZONTAL: " + horiz);
            play.getRun().setDirection(horiz);
            play.changeState(StateEnums.RunState);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rgb.AddForce(Vector2.up * Constant.jumpPower, ForceMode2D.Impulse);
            an.Play("Jump"); 
        }
        else if(Input.GetButtonDown("Roll") && grounded && !play.getRollUsed())
        {
            play.getRoll().setStartTime(Time.time);
            play.changeState(StateEnums.RollState);
            play.setRollCD();

        }
        else if(Input.GetButtonDown("Attack"))
        {
            play.changeState(StateEnums.AttackState);
        }
        else if(Input.GetButtonDown("Backstep") && !play.getBStepUsed())
        {
            play.getBack().setStartTime(Time.time);
            play.changeState(StateEnums.BackstepState);
            play.setBStepCD();

        }
    }
}
