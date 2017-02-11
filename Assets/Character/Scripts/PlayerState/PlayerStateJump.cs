using UnityEngine;

class PlayerStateJump : PlayerState
{
	public PlayerStateJump(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
		if (PlayerInput.HoldingMoveLeft())
        {
            ChangeState(PlayerStateEnum.TestMoveLeft);
        }
		else if (PlayerInput.HoldingMoveRight())
        {
            ChangeState(PlayerStateEnum.TestMoveRight);
        }
		else if (NextAnimationStarted())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
