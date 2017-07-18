using UnityEngine;
using System.Collections.Generic;

class PlayerState
{
	protected Animator _animator;
    protected GameObject _player;
    private HashSet<KeyPress> _playerInput;
    private bool _playerInputHandling;
    private bool _selfTransition;

		
	public PlayerState(Animator animator)
	{
		_animator = animator;
        _player = _animator.gameObject;
        _playerInput = null;
        _playerInputHandling = true;
        _selfTransition = false;
	}

	public void Update()
	{
        // ignore input until playing correct animation
        if (!PlayingNextAnimation() && !FinishedCurrentAnimation())
        {
            return;
        }

        if (_playerInput != null && _playerInput.Count > 0 && !FinishedCurrentAnimation())
        {
            HandleInput(_playerInput);
        }
        else if (_playerInputHandling && !FinishedCurrentAnimation())
        {
            _playerInput = PlayerInput.GetInput();
        }
        else if (_selfTransition)
        {
            AnimatorCommon.RestartCurrentAnimation(_animator);
            _selfTransition = false;
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

    // set false if your state doesn't need to deal with input - default transition to idle
    protected void EnableInputHandling(bool b)
    {
        _playerInputHandling = b;
    }
	
	protected void ChangeState(PlayerStateEnum newState)
	{
        _playerInput = null;
        _selfTransition = ((int)newState == AnimatorCommon.GetState(_animator));
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

    protected float NormalizedTime()
    {
        return AnimatorCommon.NormalizedTime(_animator);
    }

	protected bool FinishedCurrentAnimation()
	{
		return NormalizedTime() >= 1.0f && !_animator.IsInTransition(0);
	}

    // Since i do this a lot when debugging
    protected void PrintInput()
    {
        string s = "";
        if (_playerInput != null)
        {
            foreach (KeyPress k in _playerInput)
                s += k + " ";
        }
        Debug.Log(s);
    }

	bool PlayedFirstFrameOfAnimation()
	{
		return NormalizedTime() > 0;
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
