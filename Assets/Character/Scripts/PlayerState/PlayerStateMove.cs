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
        float roll_direction = PlayerInput.PressedRoll();
        if (!CollisionCommon.IsGrounded(_go))
        //if (!CollisionCommon.IsGrounded(_player))
        {
            ChangeState(PlayerStateEnum.TestAirborneMove);
        }
        else if (input.Contains(KeyPress.Jump))
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (roll_direction != 0)
		//else if (input.Contains(KeyPress.Roll))
        {
            if (roll_direction > 0)
            {
                AnimatorCommon.FaceRight(_animator);
            }
            else
            {
                AnimatorCommon.FaceLeft(_animator);
            }
            ChangeState(PlayerStateEnum.TestRoll);
        }
        else if (PlayerInput.PressedLowAttack())
        {
            ChangeState(PlayerStateEnum.TestLowAttack);
        }
        else if (PlayerInput.PressedHighAttack())
        {
            ChangeState(PlayerStateEnum.TestHighAttack);
        }
        else if(PlayerInput.PressedMidAttack())
		//else if (input.Contains(KeyPress.MidAttack))
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
        else if (NoLongerMovingLeft() || NoLongerMovingRight()) 
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }

	}
}
