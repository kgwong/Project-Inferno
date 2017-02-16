using UnityEngine;

class PlayerStateJump : PlayerState
{
	public PlayerStateJump(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
		if (PlayerInput.HoldingMoveLeft() || PlayerInput.HoldingMoveRight())
        {
            ChangeState(PlayerStateEnum.TestMove);
        }
		else if (NextAnimationStarted())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
