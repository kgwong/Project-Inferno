using UnityEngine;
using System.Collections.Generic;

class PlayerStateJump : PlayerState
{
	public PlayerStateJump(Animator animator)
		: base(animator)
    {

    }

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        ChangeState(PlayerStateEnum.TestIdle);
        //bool pressMove = input.Contains(KeyPress.MoveLeft) || input.Contains(KeyPress.MoveRight);
        //if (pressMove) 
        //{
        //    ChangeState(PlayerStateEnum.TestAirborneMove);
        //}
		//else if (FinishedCurrentAnimation())
        //{
        //    ChangeState(PlayerStateEnum.TestIdle);
        //}
    }
}
