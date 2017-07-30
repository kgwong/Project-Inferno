using UnityEngine;
using System.Collections;


//will probably need to put some delay inbetween rolls; travels faster than running

public class RollState : PlayerStates {

    private Animator an;
    private Player play;
    private Rigidbody2D rgb;
    private float startTime;


    void Start () {
        play = GetComponent<Player>();
        an = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        name = "Roll";

    }

    public override void ComponentUpdate () {
        facing = play.getRun().getFacing();
        an.Play("Roll");

        rgb.AddForce(Vector2.right * facing * Constant.moveSpeed * Constant.rollMLTP, ForceMode2D.Impulse);

        if (Time.time - startTime > Constant.rollTimer)
        {
            play.changeState(StateEnums.IdleState);
        }
        handleInput();
	}

    public override void handleInput()
    {
        //queue next input?
    }

    public void setStartTime(float s)
    {
        startTime = s;
    }
}
