using UnityEngine;

class PlayerStateHighAttack : PlayerState
{
	public PlayerStateHighAttack(Animator animator)
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
        else
        {
            IdleIfFinished();
        }
    }
}
