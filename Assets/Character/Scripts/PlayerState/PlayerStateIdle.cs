using UnityEngine;
using System.Collections.Generic;

class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(Animator animator)
        : base(animator) 
    {
    }    

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        // If a default case fell here, don't respond to input until done with animation
        if (!PlayingNextAnimation())
        {
            return;
        }
        float roll_direction = PlayerInput.PressedRoll();
        if (roll_direction != 0)
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
        else if (input.Contains(KeyPress.Jump) && IsGrounded())
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (PlayerInput.PressedMoveLeft() || PlayerInput.HoldingMoveLeft()) //do we want to add joystick sensitivity?
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (input.Contains(KeyPress.MoveRight))
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceRight(_animator);
        }
        else if (PlayerInput.PressedLowAttack())
        {
            ChangeState(PlayerStateEnum.TestLowAttack);
        }
        else if(PlayerInput.PressedHighAttack())
        {
            ChangeState(PlayerStateEnum.TestHighAttack);
        }
        else if(PlayerInput.PressedMidAttack())
		{
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
    }

    private bool IsGrounded()
    {
        return CollisionCommon.IsGrounded(_player);
    }
}
