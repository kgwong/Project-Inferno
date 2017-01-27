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

        if (PressedRoll())
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
        else if (PressedJump())
        {
            ChangeState(PlayerStateEnum.TestJump);
        }
        else if (PressedMoveLeft())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMoveLeft);
            FlipSpriteLeft();
        }
        else if (PressedMoveRight())
        {
            // unflipped = facing right
            ChangeState(PlayerStateEnum.TestMoveRight);
            FlipSpriteRight();
        }
        else if (PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
    }
}
