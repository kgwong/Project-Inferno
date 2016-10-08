using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
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
        if (_controller.InState(Constants.STATE_MOVE_LEFT))
        {
            _rb.AddForce(transform.right * -Constants.BASE_MOVE_SPEED);
        }
        else if (_controller.InState(Constants.STATE_MOVE_RIGHT))
        {
            _rb.AddForce(transform.right * Constants.BASE_MOVE_SPEED);
        }
		else if (_controller.InState(Constants.STATE_JUMP))
        {
            _rb.AddForce(transform.up * Constants.BASE_JUMP_SPEED);
        }

	}
}
