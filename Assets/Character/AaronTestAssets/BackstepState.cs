using UnityEngine;
using System.Collections;

public class BackstepState : PlayerState {


    private Rigidbody2D rgb;
    private Player play;
 //   private Animator an;
    private float startTime;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        play = GetComponent<Player>();
    //    an = GetComponent<Animator>();

    }



    public override void ComponentUpdate()
    {
        facing = -play.getRun().getFacing();


        rgb.AddForce(facing * Vector2.right * Constants.backStepSpeed * 1.5f + Vector2.up * Constants.backStepHeight, ForceMode2D.Impulse);
        
        if (Time.time - startTime > Constants.bStepTimer)
        {
            play.changeState(StateEnums.IdleState);
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
