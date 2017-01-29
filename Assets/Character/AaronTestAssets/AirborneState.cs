using UnityEngine;
using System.Collections;

public class AirborneState : PlayerState {


    private OnGround og;
    private Player play;
	// Use this for initialization
	void Start () {
        og = GetComponent<OnGround>();
        play = GetComponent<Player>();
        run = GetComponent<RunState>();
        idle = GetComponent<IdleState>();
        name = "Airborne";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IN AIR");
        if (grounded)
        {
            play.changeState(idle);
        }
    }

    public override void handleInput()
    {

    }
}
