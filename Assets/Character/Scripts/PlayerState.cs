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
        AnimatorCommon.SetState(_animator, (int)newState);
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
        return GetStateHash(AnimatorCommon.GetState(_animator)) == GetCurrentStateHash();
	}

	protected bool FinishedCurrentAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && !_animator.IsInTransition(0);
	}

	bool PlayedFirstFrameOfAnimation()
	{
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0;
	}

	int GetStateHash(int state) 
	{
        string baseLayer = "Base.";
        string stateName = ((PlayerStateEnum)state).ToString();
		return Animator.StringToHash(baseLayer + stateName);
	}

	int GetCurrentStateHash()
	{
        return _animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
	}
}