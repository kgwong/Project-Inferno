using UnityEngine;

class PlayerStateJump : PlayerState
{
	public PlayerStateJump(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
        bool pressMove = PlayerInput.HoldingMoveLeft() || PlayerInput.HoldingMoveRight();
        if (pressMove) 
        {
            ChangeState(PlayerStateEnum.TestAirborneMove);
        }
		else if (NextAnimationStarted())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
