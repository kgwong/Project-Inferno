using UnityEngine;

class PlayerStateMoveLeft : PlayerState
{
	public PlayerStateMoveLeft(Animator animator)
		: base(animator)
	{

    }

    public override void Update()
    {
        bool facingRight = AnimatorCommon.FacingRight(_animator);

        if (PlayerInput.PressedRoll())
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
        else if (PlayerInput.HoldingMoveLeft())
        {
            AnimatorCommon.FaceLeft(_animator);
        }
        else if (PlayerInput.PressedMoveRight())
        {
            AnimatorCommon.FaceRight(_animator);
            ChangeState(PlayerStateEnum.TestMoveRight);
        }
        else if (!facingRight && !PlayerInput.HoldingMoveLeft())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
