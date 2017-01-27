using UnityEngine;

class PlayerStateMoveRight : PlayerState
{
	public PlayerStateMoveRight(Animator animator)
		: base(animator)
	{

	}

	public override void Update()
	{
		bool facingRight = _animator.GetBool("facingRight");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _animator.SetBool("facingRight", false);
            ChangeState(PlayerStateEnum.TestMoveLeft);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetBool("facingRight", true);
        }
        else if (facingRight && !Input.GetKey(KeyCode.RightArrow))
        {
            ChangeState(PlayerStateEnum.TestIdle);
        }
	}
}