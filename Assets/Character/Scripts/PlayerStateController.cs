using UnityEngine;
using System.Collections.Generic;

public class PlayerStateController : MonoBehaviour
{
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	private Dictionary<PlayerStateEnum, PlayerState> _states;

	public PlayerStateEnum GetState()
	{
		return (PlayerStateEnum)_animator.GetInteger("state");
	}

	void Start()
	{
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator.SetInteger("state", (int)PlayerStateEnum.TestIdle);
		_animator.SetBool("facingRight", true);
		_states = new Dictionary<PlayerStateEnum, PlayerState>();
		
		InitStates();
	}

	void Update()
	{
		_states[GetState()].Update();
		FlipSpriteCorrectDirection();
	}

	private void FlipSpriteCorrectDirection()
	{
		_spriteRenderer.flipX = !_animator.GetBool("facingRight");
	}

	private void InitStates()
	{
		_states.Add(PlayerStateEnum.TestIdle, new PlayerStateIdle(_animator));
		_states.Add(PlayerStateEnum.TestMoveLeft, new PlayerStateMoveLeft(_animator));
		_states.Add(PlayerStateEnum.TestMoveRight, new PlayerStateMoveRight(_animator));
		_states.Add(PlayerStateEnum.TestRoll, new PlayerStateRoll(_animator));
		_states.Add(PlayerStateEnum.TestHighAttack, new PlayerStateHighAttack(_animator));
		_states.Add(PlayerStateEnum.TestMidAttack, new PlayerStateMidAttack(_animator));
		_states.Add(PlayerStateEnum.TestLowAttack, new PlayerStateLowAttack(_animator));
		_states.Add(PlayerStateEnum.TestMidAttackCombo, new PlayerStateMidCombo(_animator));
        _states.Add(PlayerStateEnum.TestJump, new PlayerStateJump(_animator));
	}
}