using UnityEngine;

class PlayerStateMove : PlayerState
{
	public PlayerStateMove(Animator animator)
		: base(animator)
	{

	}

	public override void Update()
	{
        bool facingRight = _animator.GetBool("facingRight");
		if (!facingRight && !Input.GetKey(KeyCode.LeftArrow))
		{
			ChangeState(PlayerStateEnum.TestIdle);
		}
		else if (facingRight && !Input.GetKey(KeyCode.RightArrow))
		{
			ChangeState(PlayerStateEnum.TestIdle);
		}
		else if (PressedMidAttack())
		{
			ChangeState(PlayerStateEnum.TestMidAttack);
		}
		else if (PressedRoll())
		{
			ChangeState(PlayerStateEnum.TestRoll);
		}
	}
}
