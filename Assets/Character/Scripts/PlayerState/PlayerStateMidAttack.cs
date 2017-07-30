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
		if (input.Contains(KeyPress.MidAttack))
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }
    }
}
