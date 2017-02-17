using UnityEngine;
using System.Collections;


//will probably need to put some delay inbetween rolls; travels faster than running

public class RollState : PlayerState {

    private Animator an;
    private Player play;
    private Rigidbody2D rgb;
    private float timer = 0.2f;
    private float rollMLTP = 3f;
    private float startTime;


    void Start () {
        play = GetComponent<Player>();
        an = GetComponent<Animator>();
        run = GetComponent<RunState>();
        rgb = GetComponent<Rigidbody2D>();
        idle = GetComponent<IdleState>();
        sr = GetComponent<SpriteRenderer>();
        name = "Roll";

    }

    public override void ComponentUpdate () {
        facing = run.getFacing();

        an.Play("Roll");

        rgb.AddForce(Vector2.right * facing * play.getSpeed() * rollMLTP, ForceMode2D.Impulse);

        if (Time.time - startTime > timer)
        {
            play.changeState(idle);
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
