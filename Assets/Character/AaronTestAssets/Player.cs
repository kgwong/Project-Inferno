using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private PlayerState state_;
    private float moveSpeed = 3f;
    private float jumpPower = 8f;
    private OnGround og;
    // Use this for initialization
    private IdleState idle;

	void Start () {
        idle = GetComponent<IdleState>();
        state_ = idle;
        og = GetComponent<OnGround>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        state_.setGrounded(og.checkGrounded());
        Debug.Log(og.checkGrounded());
        state_.ComponentUpdate();
	}

    public void changeState(PlayerState state)
    {
        Debug.Log("Switch state to: " + state.name);
        state_ = state; 
    }

    public float getSpeed()
    {
        return moveSpeed;
    }

    public void setSpeed(float s)
    {
        moveSpeed = s;
    }

    public float getJump()
    {
        return jumpPower;
    }
}
