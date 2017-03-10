using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private PlayerState state_;
    private float moveSpeed = 3f;
    private float jumpPower = 8f;
    private float cooldown = 1f;
    private float rollCDTimer;
    private float bStepCDTimer;
    private bool rollUsed;
    private bool bStepUsed;
    private OnGround og;
    // Use this for initialization
    private IdleState idle;

	void Start () {
        idle = GetComponent<IdleState>();
        state_ = idle;
        og = GetComponent<OnGround>();
        rollUsed = false;
        bStepUsed = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(rollUsed)
        {
            rollCDTimer += Time.deltaTime;
            if(cooldown < rollCDTimer)
            {
                rollUsed = false;
            }
        }

        if(bStepUsed)
        {
            bStepCDTimer += Time.deltaTime;
            if(cooldown < bStepCDTimer)
            {
                bStepUsed = false;
            }
        }
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

    public float getCooldown()
    {
        return cooldown;
    }

    public void setRollCD()
    {
        rollCDTimer = 0;
        rollUsed = true;
    }

    public void setBStepCD()
    {
        bStepCDTimer = 0;
        bStepUsed = true;
    }

    public bool getRollUsed()
    {
        return rollUsed;
    }

    public bool getBStepUsed()
    {
        return bStepUsed;
    }
}
