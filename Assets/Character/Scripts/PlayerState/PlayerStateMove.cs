﻿using UnityEngine;

class PlayerStateMove: PlayerState
{
	public PlayerStateMove(Animator animator)
		: base(animator)
	{

	}

	public override void Update()
	{

		if (PlayerInput.PressedRoll())
        {
            ChangeState(PlayerStateEnum.TestRoll);
        }
		else if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
        else if (PlayerInput.HoldingMoveRight())
        {
            AnimatorCommon.FaceRight(_animator);
        }
        else if (PlayerInput.HoldingMoveLeft())
        {
			AnimatorCommon.FaceLeft(_animator);
        }
        else if (NoLongerMovingLeft() || NoLongerMovingRight()) 
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
	}

    private bool NoLongerMovingLeft()
    {
        bool facingRight = AnimatorCommon.FacingRight(_animator);
        return !facingRight && !PlayerInput.HoldingMoveLeft();
    }

    private bool NoLongerMovingRight()
    {
        bool facingRight = AnimatorCommon.FacingRight(_animator);
        return facingRight && !PlayerInput.HoldingMoveRight();
    }
}