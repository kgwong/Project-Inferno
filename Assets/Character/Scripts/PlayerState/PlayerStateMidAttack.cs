using UnityEngine;
using System.Collections.Generic;

class PlayerStateMidAttack : PlayerState
{
	public PlayerStateMidAttack(Animator animator)
		: base(animator)
    {

    }

    protected override void HandleInput(HashSet<KeyPress> input)
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
	//	if (input.Contains(KeyPress.MidAttack))
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }
    }
}
