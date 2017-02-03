using UnityEngine;
using System.Collections;

public class AirborneState : PlayerState {


    private Player play;
	// Use this for initialization
	void Start () {
        play = GetComponent<Player>();
        run = GetComponent<RunState>();
        idle = GetComponent<IdleState>();
        name = "Airborne";
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
