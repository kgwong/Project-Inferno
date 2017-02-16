using UnityEngine;

class PlayerStateMidAttack : PlayerState
{
	public PlayerStateMidAttack(Animator animator)
		: base(animator)
    {

    }

    public override void Update()
    {
		if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttackCombo);
        }
        else
        {
            IdleIfFinished();
        }
    }
}
