using UnityEngine;

class PlayerStateMoveRight : PlayerState
{
	public PlayerStateMoveRight(Animator animator)
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
        else if (PlayerInput.HoldingMoveRight())
        {
            AnimatorCommon.FaceRight(_animator);
        }
        else if (PlayerInput.PressedMoveLeft())
        {
			AnimatorCommon.FaceLeft(_animator);
            ChangeState(PlayerStateEnum.TestMoveLeft);
        }
        else if (facingRight && !PlayerInput.HoldingMoveRight()) 
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
	}
}