using UnityEngine;
using System.Collections;

public class IdleState : PlayerState {

    private Animator an;
    private Player p;
    private RunState runState;
	// Use this for initialization
	void Start () {
        p = GetComponent<Player>();
        an = GetComponent<Animator>();
        runState = GetComponent<RunState>();
	}
	
	// Update is called once per frame
	public override void Update () {
	}

    public override void ComponentUpdate()
    {
        Debug.Log("IDLE");
        an.Play("Idle");
        handleInput();
    }

    public override void handleInput()
    {

        float horiz = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right"))
        {
            Debug.Log("HORIZONTAL: " + horiz);
            runState.setDirection(horiz);
            p.changeState(runState);
        }
    }
}
