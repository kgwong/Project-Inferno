using UnityEngine;

class PlayerStateMoveLeft : PlayerState
{
	public PlayerStateMoveLeft(Animator animator)
		: base(animator)
	{

    }

    public override void Update()
    {
		bool facingRight = _animator.GetBool("facingRight");
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            _animator.SetBool("facingRight", false);
        }
		else if (Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("facingRight", true);
            ChangeState(PlayerStateEnum.TestMoveRight);
        }
		else if (!facingRight && !Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
    }
}
