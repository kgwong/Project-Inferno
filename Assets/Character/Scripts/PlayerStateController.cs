using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
	public Animator animator;

    private SpriteRenderer _spriteRenderer;
	private bool _facingRight;
    float _distToGround;

	void Start ()
	{
		animator = this.GetComponent<Animator>();
		animator.SetInteger("state", Constants.STATE_IDLE);
        _facingRight = true;
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _distToGround = this.GetComponent<Collider2D>().bounds.extents.y;
	}

    void Update()
    {
        if (InState(Constants.STATE_IDLE))
        {
            IdleStateUpdate();
        }
        else if (InState(Constants.STATE_MID_ATTACK))
        {
            MidAttackStateUpdate();
        }
        else if (InState(Constants.STATE_MOVE_LEFT) || InState(Constants.STATE_MOVE_RIGHT))
        {
            MoveStateUpdate();
        }
        else if (InState(Constants.STATE_ROLL))
        {
            RollStateUpdate();
        }
		else if (InState(Constants.STATE_JUMP))
		{
            JumpStateUpdate();
        }
	}

	public bool InState(int state)
	{
		return animator.GetInteger("state") == state;
	}

	void ChangeState(int newState)
	{
		if (!InState(newState))
		{
			animator.SetInteger("state", newState);
		}
	}

	bool PressedRoll()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}

	bool PressedMidAttack()
	{
		return Input.GetKeyDown(KeyCode.A);
	}

	bool PressedJump()
    {
        return Input.GetKey(KeyCode.B);
    }
	bool PressedMoveLeft()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }
	bool PressedMoveRight()
    {
        return Input.GetKeyDown(KeyCode.RightArrow);
    }

	void IdleStateUpdate()
    {
		if (!IsGrounded())
        {
            return;
        }

		if (PressedRoll())
		{
			ChangeState(Constants.STATE_ROLL);
		}
		else if (PressedJump())
        {
            ChangeState(Constants.STATE_JUMP);
        }
		else if (PressedMoveLeft())
        {
            // default face right
            ChangeState(Constants.STATE_MOVE_LEFT);
			_spriteRenderer.flipX = true;
            _facingRight = false;
        }
		else if (PressedMoveRight())
        {
            // default face right
            ChangeState(Constants.STATE_MOVE_RIGHT);
            _spriteRenderer.flipX = false;
            _facingRight = true;
        }
		else if (PressedMidAttack())
		{
			ChangeState(Constants.STATE_MID_ATTACK);
            _spriteRenderer.flipX = (_facingRight) ? false : true;
		}
    }

	void MidAttackStateUpdate()
    {
        if (PressedMidAttack())
        {
            ChangeState(Constants.STATE_MID_COMBO);
            _spriteRenderer.flipX = (_facingRight) ? false : true;
        }
        else
        {
            ChangeState(Constants.STATE_IDLE);
        }
    }

	void MoveStateUpdate()
    {
		if (!_facingRight && !Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeState(Constants.STATE_IDLE);
        }

		if (_facingRight && !Input.GetKey(KeyCode.RightArrow))
        {
            ChangeState(Constants.STATE_IDLE);
        }
    }

	void RollStateUpdate()
    {
        ChangeState(Constants.STATE_IDLE);
    }

	void JumpStateUpdate()
    {
        ChangeState(Constants.STATE_IDLE);
    }

	bool IsGrounded()
    {
        float pad = .1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, _distToGround + pad);
        bool result = hit.collider != null;
        return result;
    }
}
