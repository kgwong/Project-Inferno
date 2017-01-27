using UnityEngine;
using System.Collections;

public class RunState : PlayerState {

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
        an.Play("Walk");
        
       
        rgb.AddForce(Vector2.right * direction * play.getSpeed(), ForceMode2D.Impulse);
        Flip();
        Debug.Log("direction: " + direction + ", speed: " + rgb.velocity.x);

        handleInput();
    }

    public override void handleInput()
    {
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
