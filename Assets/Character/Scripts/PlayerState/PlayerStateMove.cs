using UnityEngine;
using System.Collections.Generic;

class PlayerStateMove: PlayerState
{
	public PlayerStateMove(Animator animator)
		: base(animator)
	{

	}

    protected override void HandleInput(HashSet<KeyPress> input)
	{
        if (!CollisionCommon.IsGrounded(_go))
        {
            ChangeState(PlayerStateEnum.TestAirborneMove);
        }
        else if (input.Contains(KeyPress.Jump))
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
		else if (input.Contains(KeyPress.Roll))
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
		else if (input.Contains(KeyPress.MidAttack))
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
        else if (input.Contains(KeyPress.MoveRight))
        {
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceRight(_animator);
        }
        else if (input.Contains(KeyPress.MoveLeft))
        {
            ChangeState(PlayerStateEnum.TestMove);
			AnimatorCommon.FaceLeft(_animator);
        }
	}
}
