using UnityEngine;
using System.Collections;

public class RunState : PlayerState {

    private float direction;
    private Rigidbody2D rgb;
    private Player play;
    private IdleState idle;
    private Animator an;

    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        play = GetComponent<Player>();
        idle = GetComponent<IdleState>();
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	public override void Update () {

	}

    public override void ComponentUpdate()
    {
        Debug.Log("direction: " + direction + ", speed: " + play.getSpeed());
        an.Play("Walk");
            //Flip(direction);

        rgb.AddForce(Vector2.right * direction * play.getSpeed(), ForceMode2D.Impulse);
        handleInput();
    }

    public override void handleInput()
    {
        if (Input.GetButton("Left"))
        {
            direction = -1;
        }
        else if (Input.GetButton("Right"))
        {
            direction = 1;
        }
        else 
        {
            direction = 0;
            play.changeState(idle);
        }
    }


    public void setDirection(float d)
    {
        direction = d;
    }

    public float getDirection()
    {
        return direction;
    }
}
