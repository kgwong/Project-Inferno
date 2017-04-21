﻿using UnityEngine;

class PlayerStateLowAttack : PlayerState
{
	public PlayerStateLowAttack(Animator animator)
		: base(animator)
	{

	}

    public override void Update()
    {
        if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }

        else if (PlayerInput.PressedHighAttack()) //S button
        {
            ChangeState(PlayerStateEnum.TestHighAttackCombo);
        }
        else if(PlayerInput.PressedLowAttack())
        {
            ChangeState(PlayerStateEnum.TestLowAttackCombo);
        }
        else
        {
            IdleIfFinished();
        }
    }
}
