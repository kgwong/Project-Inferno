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
        //airborne = GetComponent<AirborneState>();
        name = "Idle";
	}
	
	// Update is called once per frame
	public override void Update () {
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IDLE");
        an.Play("Idle");
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
        }
    }
}
