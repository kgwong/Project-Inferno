using UnityEngine;

class PlayerStateAirborneMove : PlayerState
{
    public PlayerStateAirborneMove(Animator animator)
        : base(animator)
    {
    }

    public override void Update()
    {
        if (CollisionCommon.IsGrounded(_go))
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
        else if (PlayerInput.PressedMoveLeft() || PlayerInput.HoldingMoveLeft())
        {
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (PlayerInput.PressedMoveRight() || PlayerInput.HoldingMoveRight())
        {
            AnimatorCommon.FaceRight(_animator);
        }
    }

}
