using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private PlayerStateController _controller;
	private Rigidbody2D _rb;

	void Start()
	{
		_controller = GetComponent<PlayerStateController>();
		_rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		switch (_controller.GetState())
		{
			case PlayerStateEnum.TestMoveLeft:
				_rb.AddForce(transform.right * -Constants.BASE_MOVE_SPEED);
				break;
			case PlayerStateEnum.TestMoveRight:
				_rb.AddForce(transform.right * Constants.BASE_MOVE_SPEED);
				break;
			case PlayerStateEnum.TestJump:
				if (CollisionCommon.IsGrounded(gameObject))
					_rb.AddForce(transform.up * Constants.BASE_JUMP_SPEED);
				break;
			case PlayerStateEnum.TestRoll:
                int dir = (_controller.FacingRight()) ? 1 : -1;
                _rb.AddRelativeForce(transform.right * Constants.BASE_ROLL_SPEED * dir);
				break;
		}
	}
}
