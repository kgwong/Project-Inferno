using UnityEngine;
using System.Collections;

public class AirborneState : PlayerState {


    private Player play;
    private Rigidbody2D rgb;
    private Animator an;

	void Start () {
        play = GetComponent<Player>();
        run = GetComponent<RunState>();
        idle = GetComponent<IdleState>();
        name = "Airborne";
        rgb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IN AIR");
        if (grounded)
        {
            play.changeState(idle);
        }


        if (!an.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !an.GetCurrentAnimatorStateInfo(0).IsName("Jump")) //?? doesn't work here
        {
            an.Play("Walk");
        }
        Debug.Log("DIRECTION: " + direction);

        //determine this based on previous speed? it is determined by how fast GetAxis ramps down from 1/-1 back to 0
        //this is the speed you get if you aren't pressing anything
        direction = Input.GetAxis("Horizontal");
        rgb.AddForce(Vector2.right * direction * (play.getSpeed()), ForceMode2D.Impulse);

        //how fast 0 goes to 1 for GetAxis determines how fast the player can pick up/change speed in the air (and therefore how far)
        //play.getSpeed() here just determines max air speed when direction is -1 or 1


        Flip();
        handleInput();

    }

    public override void handleInput() //wtf is happening
    {

    }
}
