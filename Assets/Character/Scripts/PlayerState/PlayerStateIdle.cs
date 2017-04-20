﻿ using UnityEngine;

class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(Animator animator)
        : base(animator) 
    {
    }    

    public override void Update()
    {
        // If a default case fell here, don't respond to input until done with animation
        if (!PlayingNextAnimation())
        {
            return;
        }

        if (PlayerInput.PressedRoll())
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
        else if (PlayerInput.PressedJump() && IsGrounded())
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (PlayerInput.PressedMoveLeft() || PlayerInput.HoldingMoveLeft())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (PlayerInput.PressedMoveRight() || PlayerInput.HoldingMoveRight())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceRight(_animator);
        }
        else if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
        else if(PlayerInput.PressedHighAttack())
        {
            ChangeState(PlayerStateEnum.TestHighAttack);
        }
    }

    private bool IsGrounded()
    {
        return CollisionCommon.IsGrounded(_go);
    }
}
