﻿using UnityEngine;

class PlayerStateMidAttack : PlayerState
{
	public PlayerStateMidAttack(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
		if (PlayerInput.PressedLowAttack())
        {
            ChangeState(PlayerStateEnum.TestLowAttackCombo);
        }

        else if(PlayerInput.PressedHighAttack()) //S button
        {
            ChangeState(PlayerStateEnum.TestHighAttackCombo);
        }
        else if(PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }
        else
        {
            IdleIfFinished();
        }
    }
}
