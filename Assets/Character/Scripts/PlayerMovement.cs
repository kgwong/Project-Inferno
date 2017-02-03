﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private PlayerStateController _controller;
	private Rigidbody2D _rb;

	void Start()
	{
		_controller = this.GetComponent<PlayerStateController>();
		_rb = this.GetComponent<Rigidbody2D>();
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
				if (CollisionCommon.IsGrounded(this.gameObject))
					_rb.AddForce(transform.up * Constants.BASE_JUMP_SPEED);
				break;
			case PlayerStateEnum.TestRoll:
				// fix me
				break;
		}
	}
}
