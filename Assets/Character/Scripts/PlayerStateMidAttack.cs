using UnityEngine;

class PlayerStateMidAttack : PlayerState
{
	public PlayerStateMidAttack(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
		if (PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }
		else if (FinishedCurrentAnimation())
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
