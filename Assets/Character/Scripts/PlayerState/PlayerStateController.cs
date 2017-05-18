using UnityEngine;
using System.Collections.Generic;

public class PlayerStateController : MonoBehaviour
{
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	private Dictionary<PlayerStateEnum, PlayerState> _states;

	public PlayerStateEnum GetState()
	{
		return (PlayerStateEnum)AnimatorCommon.GetState(_animator);
	}

	public bool FacingRight()
    {
        return AnimatorCommon.FacingRight(_animator);
    }

	void Start()
	{
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_states = new Dictionary<PlayerStateEnum, PlayerState>();

        AnimatorCommon.FaceRight(_animator);
        AnimatorCommon.SetState(_animator, (int)(PlayerStateEnum.TestIdle));
		InitStates();
	}

	void Update()
	{
		_states[GetState()].Update();
		FlipSpriteCorrectDirection();
	}

	private void FlipSpriteCorrectDirection()
	{
        AnimatorCommon.FlipSpriteCorrectDirection(_animator, _spriteRenderer);
	}

	private void InitStates()
	{
		_states.Add(PlayerStateEnum.TestIdle, new PlayerStateIdle(_animator));
		_states.Add(PlayerStateEnum.TestMove, new PlayerStateMove(_animator));
		_states.Add(PlayerStateEnum.TestRoll, new PlayerStateRoll(_animator));
		_states.Add(PlayerStateEnum.TestHighAttack, new PlayerStateHighAttack(_animator));
		_states.Add(PlayerStateEnum.TestMidAttack, new PlayerStateMidAttack(_animator));
		_states.Add(PlayerStateEnum.TestLowAttack, new PlayerStateLowAttack(_animator));
		_states.Add(PlayerStateEnum.TestMidAttackCombo, new PlayerStateMidCombo(_animator));
        _states.Add(PlayerStateEnum.TestJump, new PlayerStateJump(_animator));
        _states.Add(PlayerStateEnum.TestAirborneMove, new PlayerStateAirborneMove(_animator));
        _states.Add(PlayerStateEnum.TestHighAttackCombo, new PlayerStateHighCombo(_animator));
        _states.Add(PlayerStateEnum.TestLowAttackCombo, new PlayerStateLowCombo(_animator));
        _states.Add(PlayerStateEnum.TestBackstep, new PlayerStateBackstep(_animator));
	}
}
