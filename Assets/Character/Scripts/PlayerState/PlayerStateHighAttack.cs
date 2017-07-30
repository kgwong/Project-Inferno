using UnityEngine;
using System.Collections.Generic;

class PlayerStateHighAttack : PlayerState
{
	public PlayerStateHighAttack(Animator animator)
		: base(animator)
    {

    }

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        if (PlayerInput.PressedLowAttack())
        {
            ChangeState(PlayerStateEnum.TestLowAttackCombo);
        }

        else if (PlayerInput.PressedHighAttack()) //S button
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
