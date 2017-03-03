using UnityEngine;
using System.Collections;

public class BackstepState : PlayerState {


    private Rigidbody2D rgb;
    private Player play;
 //   private Animator an;
    private float timer = 0.08f;
    private float backStepSpeed = 5f;
    private float backStepHeight = 0.6f;
    private float startTime;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        play = GetComponent<Player>();
    //    an = GetComponent<Animator>();
        idle = GetComponent<IdleState>();
        run = GetComponent<RunState>();
    }



    public override void ComponentUpdate()
    {
        facing = -run.getFacing();

        rgb.AddForce(facing * Vector2.right * backStepSpeed * 1.5f + Vector2.up * backStepHeight, ForceMode2D.Impulse);
        
        if (Time.time - startTime > timer)
        {
            play.changeState(idle);
        }
        handleInput();
    }

    public override void handleInput()
    {

    }

    public void setStartTime(float s)
    {
        startTime = s;
    }
}
