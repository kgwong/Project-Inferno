using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	private bool _facingRight;

	public int GetState()
	{
		return _animator.GetInteger("state");
	}

	void Start ()
	{
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator.SetInteger("state", Constants.STATE_IDLE);
		_facingRight = true;
	}

	void Update()
	{
		switch (GetState())
		{
			case Constants.STATE_IDLE:
				IdleStateUpdate();
				break;
			case Constants.STATE_HIGH_ATTACK:
				HighAttackStateUpdate();
				break;
			case Constants.STATE_MID_ATTACK:
				MidAttackStateUpdate();
				break;
			case Constants.STATE_LOW_ATTACK:
				LowAttackStateUpdate();
				break;
			case Constants.STATE_MOVE_LEFT:
			case Constants.STATE_MOVE_RIGHT:
				MoveStateUpdate();
				break;
			default:
				// always let next animation play for a frame before switching state
				// "Has Exit Time" will determine if we immediately switch or not
				if (NextAnimationStarted())
					ChangeState(Constants.STATE_IDLE);
				break;
		}
	}

	bool InState(int state)
	{
		return _animator.GetInteger("state") == state;
	}

	void ChangeState(int newState)
	{
		if (!InState(newState))
		{
			_animator.SetInteger("state", newState);
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
		// If a default case fell here, don't respond to input until done with animation
		if (!PlayingNextAnimation())
			return;

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
			// unflipped = facing right
			ChangeState(Constants.STATE_MOVE_LEFT);
			FlipSpriteLeft();
		}
		else if (PressedMoveRight())
		{
			// unflipped = facing right
			ChangeState(Constants.STATE_MOVE_RIGHT);
			FlipSpriteRight();
		}
		else if (PressedMidAttack())
		{
			ChangeState(Constants.STATE_MID_ATTACK);
			FlipSpriteCorrectDirection();
		}
	}

	void JumpStateUpdate()
	{
		ChangeState(Constants.STATE_IDLE);
	}
	
	void HighAttackStateUpdate()
	{

	}

	void MidAttackStateUpdate()
	{
		if (PressedMidAttack())
		{
			ChangeState(Constants.STATE_MID_COMBO);
		}
		else if (FinishedCurrentAnimation())
		{
			ChangeState(Constants.STATE_IDLE);
		}
	}

	void LowAttackStateUpdate()
	{

	}

	void MoveStateUpdate()
	{
		if (!_facingRight && !Input.GetKey(KeyCode.LeftArrow))
		{
			ChangeState(Constants.STATE_IDLE);
		}
		else if (_facingRight && !Input.GetKey(KeyCode.RightArrow))
		{
			ChangeState(Constants.STATE_IDLE);
		}
		else if (PressedMidAttack())
		{
			ChangeState(Constants.STATE_MID_ATTACK);
		}
		else if (PressedRoll())
		{
			ChangeState(Constants.STATE_ROLL);
		}
	}

	void FlipSpriteRight()
	{
		_spriteRenderer.flipX = false;
		_facingRight = true;
	}

	void FlipSpriteLeft()
	{
		_spriteRenderer.flipX = true;
		_facingRight = false;
	}

	void FlipSpriteCorrectDirection()
	{
		_spriteRenderer.flipX = !_facingRight;
	}

	bool FinishedCurrentAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && !_animator.IsInTransition(0);
	}

	bool NextAnimationStarted()
	{
		return PlayingNextAnimation() && PlayedFirstFrameOfAnimation();
	}

	bool PlayingNextAnimation()
	{
		// is _animator.GetInteger("state") the same as the one that's playing?
		return GetStateHash(GetState()) == GetCurrentStateHash();
	}

	bool PlayedFirstFrameOfAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0;
	}

	int GetStateHash(int state)
	{
		switch(state)
		{
			// Animator.fullPathHash needs the "Base Layer." in .StringToHash call
			case Constants.STATE_IDLE:
				return Animator.StringToHash("Base Layer.TestIdle");
			case Constants.STATE_MOVE_LEFT:
				return Animator.StringToHash("Base Layer.TestMoveLeft");
			case Constants.STATE_MOVE_RIGHT:
				return Animator.StringToHash("Base Layer.TestMoveRight");
			case Constants.STATE_ROLL:
				return Animator.StringToHash("Base Layer.TestRoll");
			case Constants.STATE_MID_ATTACK:
				return Animator.StringToHash("Base Layer.TestMidAttack");
			case Constants.STATE_MID_COMBO:
				return Animator.StringToHash("Base Layer.TestMidAttackCombo");
			case Constants.STATE_JUMP:
				return Animator.StringToHash("Base Layer.TestJump");
			default:
				Debug.Log("STATE \"" + state + "\" IS NOT VALID");
				return 0;
		}
	}

	int GetCurrentStateHash()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
	}
}