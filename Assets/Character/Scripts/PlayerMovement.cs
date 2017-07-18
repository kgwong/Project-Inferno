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
        int dir = (_controller.FacingRight()) ? 1 : -1;
		switch (_controller.GetState())
		{
			case PlayerStateEnum.TestMove:
            case PlayerStateEnum.TestAirborneMove:
				_rb.AddRelativeForce(transform.right * Constants.BASE_MOVE_SPEED * dir);
				break;
			case PlayerStateEnum.TestJump:
				if (CollisionCommon.IsGrounded(gameObject))
					_rb.AddRelativeForce(transform.up * Constants.BASE_JUMP_SPEED);
				break;
			case PlayerStateEnum.TestRoll:
                _rb.AddRelativeForce(transform.right * Constants.BASE_ROLL_SPEED * dir);
				break;
            case PlayerStateEnum.TestBackstep:
                _rb.AddRelativeForce(Vector2.right * Constants.BACKSTEP_SPEED * 1.5f + Vector2.up * Constants.BACKSTEP_HEIGHT, ForceMode2D.Impulse);
                break;
		}
	}
}
