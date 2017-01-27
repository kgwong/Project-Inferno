using UnityEngine;

class PlayerState
{
	protected Animator _animator;
		
	public PlayerState(Animator animator)
	{
		_animator = animator;
	}
	public virtual void Update()
	{
		// always let next animation play for a frame before switching state
		// "Has Exit Time" will determine if we immediately switch or not
		if (NextAnimationStarted())
			ChangeState(PlayerStateEnum.TestIdle);
	}
	
	protected void ChangeState(PlayerStateEnum newState)
	{
		_animator.SetInteger("state", (int)newState);
	}

	protected bool NextAnimationStarted()
	{
		return PlayingNextAnimation() && PlayedFirstFrameOfAnimation();
	}

	protected bool PlayingNextAnimation()
	{
        // after _animator.SetInteger("state"), takes a few frames before actually changing animation
        // however, the int itself is changed
        // is _animator.GetInteger("state") the same as the one that's playing?
		return GetStateHash(_animator.GetInteger("state")) == GetCurrentStateHash();
	}

	protected void FlipSpriteLeft()
	{
		_animator.SetBool("facingRight", false);
	}

	protected void FlipSpriteRight()
	{
		_animator.SetBool("facingRight", true);
	}

	protected bool PressedRoll()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}

	protected bool PressedMidAttack()
	{
		return Input.GetKeyDown(KeyCode.A);
	}

	protected bool PressedJump()
	{
		return Input.GetKey(KeyCode.B);
	}
	protected bool PressedMoveLeft()
	{
		return Input.GetKeyDown(KeyCode.LeftArrow);
	}
	protected bool PressedMoveRight()
	{
		return Input.GetKeyDown(KeyCode.RightArrow);
	}

	protected bool FinishedCurrentAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && !_animator.IsInTransition(0);
	}

	bool PlayedFirstFrameOfAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0;
	}

	int GetStateHash(int state) // hack
	{
        // alternative: make all of the enums named the same as the states
        // compare to short hash instead of fullpathhash
        // downside: enums and state names must be typed correctly
        // downside: enums must be named exactly as the states
        // upside: don't need this hacky, fragile section
        // return Animator.StringToHash(state.toString())
        /*switch (state)
		{
			// Animator.fullPathHash needs the "Base Layer." in .StringToHash call
			case (int)PlayerStateEnum.STATE_IDLE:
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
		}*/
        string baseLayer = "Base.";
        string stateName = ((PlayerStateEnum)state).ToString();
		return Animator.StringToHash(baseLayer + stateName);
	}

	int GetCurrentStateHash()
	{
        return _animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
	}
}
