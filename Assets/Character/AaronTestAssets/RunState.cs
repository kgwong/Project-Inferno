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
        //airborne = GetComponent<AirborneState>();
        idle = GetComponent<IdleState>();
        roll = GetComponent<RollState>();
        attack = GetComponent<AttackState>();
        name = "Run";
    }



    public override void ComponentUpdate()
    {
        Debug.Log("direction: " + direction + ", speed: " + rgb.velocity.x);

        an.Play("Walk");
        
       
        rgb.AddForce(Vector2.right * direction * play.getSpeed(), ForceMode2D.Impulse);
        Flip();


        //if(!grounded)
        //{
        //    play.changeState(airborne);
        //}
        handleInput();
    }

    public override void handleInput()
    {
        if (Input.GetButtonDown("Attack"))
        {
            play.changeState(attack);
        }
        if (Input.GetButtonDown("Roll") && grounded)
        {
            roll.setStartTime(Time.time);
            play.changeState(roll);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("JUMP");
            rgb.AddForce(Vector2.up * play.getJump(), ForceMode2D.Impulse);
            //an.Play("Jump"); gets overwritten by other states animations
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
            play.changeState(idle);
        }
    }


}
