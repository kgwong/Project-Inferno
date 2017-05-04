using UnityEngine;
using System.Collections.Generic;

class PlayerStateAirborneMove : PlayerState
{
    public PlayerStateAirborneMove(Animator animator)
        : base(animator)
    {
    }

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        if (CollisionCommon.IsGrounded(_go))
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
        else if (input.Contains(KeyPress.MoveLeft))
        {
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (input.Contains(KeyPress.MoveRight))
        {
            AnimatorCommon.FaceRight(_animator);
        }
    }

}
