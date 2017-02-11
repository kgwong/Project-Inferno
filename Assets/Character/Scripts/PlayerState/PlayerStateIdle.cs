using UnityEngine;

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
        else if (PlayerInput.PressedJump() && canJump())
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (PlayerInput.PressedMoveLeft() || PlayerInput.HoldingMoveLeft())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMoveLeft);
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (PlayerInput.PressedMoveRight() || PlayerInput.HoldingMoveRight())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMoveRight);
            AnimatorCommon.FaceRight(_animator);
        }
        else if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
    }

    private bool canJump()
    {
        return CollisionCommon.IsGrounded(_animator.gameObject);
    }
}
