using UnityEngine;
using System.Collections;

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
            case Constants.STATE_MOVE_LEFT:
                _rb.AddForce(transform.right * -Constants.BASE_MOVE_SPEED);
                break;
            case Constants.STATE_MOVE_RIGHT:
                _rb.AddForce(transform.right * Constants.BASE_MOVE_SPEED);
                break;
            case Constants.STATE_JUMP:
                _rb.AddForce(transform.up * Constants.BASE_JUMP_SPEED);
                break;
            case Constants.STATE_ROLL:
                // roll the right way
                break;
        }
	}
}
