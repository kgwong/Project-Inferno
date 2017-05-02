using UnityEngine;
using System.Collections.Generic;

class PlayerState
{
	protected Animator _animator;
    protected GameObject _go;
    private HashSet<KeyPress> _input;
		
	public PlayerState(Animator animator)
	{
		_animator = animator;
        _go = _animator.gameObject;
        _input = null;
	}

	public void Update()
	{
        // ignore input until playing correct animation
        // potential bug -> transition to own state
        //if (!PlayingNextAnimation())
        //{
        //    return;
        //}
        
        if (_input != null && _input.Count > 0)
        {
            HandleInput(_input);
        }
        else if (!FinishedCurrentAnimation())
        {
            _input = PlayerInput.GetInput();
        }
        else if (AnimatorCommon.GetState(_animator) == (int)PlayerStateEnum.TestIdle)
        {
            AnimatorCommon.RestartCurrentAnimation(_animator);
        }
        else
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
	}

    protected virtual void HandleInput(HashSet<KeyPress> input)
    {
        // override this if your state should respond to input
        ChangeState(PlayerStateEnum.TestIdle);
    }
	
	protected void ChangeState(PlayerStateEnum newState)
	{
        _input = null;

        //if ((int)newState != AnimatorCommon.GetState(_animator))
        //{
        //    Debug.Log("Change State to " + (int)newState + ", currently " + _animator.GetInteger("state"));
        //}

        AnimatorCommon.SetState(_animator, (int)newState);
	}

    protected void IdleIfFinished()
    {
        if (FinishedCurrentAnimation())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
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
		return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;// && !_animator.IsInTransition(0);
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
