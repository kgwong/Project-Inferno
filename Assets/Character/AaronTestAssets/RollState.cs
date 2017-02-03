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
        an.Play("Roll");
        
        //I shouldn't have to do this; not sure why setting these in RunState is only temporary
        if (sr.flipX == true)
        {
            facing = -1;
        }
        else
        {
            facing = 1;
        }
        rgb.AddForce(Vector2.right * facing * play.getSpeed() * 2, ForceMode2D.Impulse);

        Debug.Log("start time: " + startTime + "time passed: : " + (startTime - Time.time));
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
