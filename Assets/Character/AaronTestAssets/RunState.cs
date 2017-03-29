using UnityEngine;
using System.Collections;

public class RunState : PlayerState {

    private Rigidbody2D rgb;
    private Player play;
    private Animator an;


    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        play = GetComponent<Player>();
        an = GetComponent<Animator>();
        name = "Run";

    }



    public override void ComponentUpdate()
    {
        Debug.Log("direction: " + direction + ", speed x: " + rgb.velocity.x);

        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !an.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            an.Play("Walk");   
        }



        rgb.AddForce(Vector2.right * direction * Constants.moveSpeed, ForceMode2D.Impulse);
        Flip();
        

        if(!grounded)
        {
            play.changeState(StateEnums.AirborneState);
        }
        handleInput();
    }

    public override void handleInput()
    {
        if (Input.GetButtonDown("Backstep") && grounded && !play.getBStepUsed())
        {
            play.getBack().setStartTime(Time.time);
            play.changeState(StateEnums.BackstepState);
            play.setBStepCD();
        }

        if (Input.GetButtonDown("Attack"))
        {
            play.changeState(StateEnums.AttackState);
        }
        if (Input.GetButtonDown("Roll") && grounded && !play.getRollUsed())
        {
            play.getRoll().setStartTime(Time.time);
            play.changeState(StateEnums.RollState);
            play.setRollCD();
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("JUMP");
            rgb.AddForce(Vector2.up * Constants.jumpPower, ForceMode2D.Impulse);
            an.Play("Jump"); //gets overwritten by other states animations
        }
        if (Input.GetButton("Left"))
        {
            setDirection(-1);
        }
        else if (Input.GetButton("Right"))
        {
            setDirection(1);
        }

        else 
        {
            setDirection(0);
            play.changeState(StateEnums.IdleState);
        }
    }

    public int getFacing()
    {
        return facing;
    }
}
