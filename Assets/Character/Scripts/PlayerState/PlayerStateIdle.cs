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
        if (input.Contains(KeyPress.Roll))
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
        else if (input.Contains(KeyPress.Jump) && IsGrounded())
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (input.Contains(KeyPress.MoveLeft))
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
        else if (input.Contains(KeyPress.MidAttack))
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
    }

    private bool IsGrounded()
    {
        return CollisionCommon.IsGrounded(_go);
    }
}
