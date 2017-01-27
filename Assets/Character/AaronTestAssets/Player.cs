using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private PlayerState state_;
    private float moveSpeed = 3f;
    // Use this for initialization
    private IdleState idle;
	void Start () {
        idle = GetComponent<IdleState>();
        state_ = idle;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        state_.ComponentUpdate();
	}

    public void changeState(PlayerState state)
    {
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
}
