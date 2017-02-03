using UnityEngine;

class PlayerStateRoll : PlayerState
{
	public PlayerStateRoll(Animator animator)
		: base(animator)
    {
		
    }

    public override void Update()
    {
		if (PlayerInput.PressedMoveRight())
        {
            ChangeState(PlayerStateEnum.TestMoveRight);
            AnimatorCommon.FaceRight(_animator);
        }
		else if (PlayerInput.PressedMoveLeft())
        {
            ChangeState(PlayerStateEnum.TestMoveLeft);
            AnimatorCommon.FaceLeft(_animator);
        }
		else
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
