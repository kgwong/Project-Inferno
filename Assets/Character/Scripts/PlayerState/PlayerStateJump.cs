using UnityEngine;
using System.Collections.Generic;

class PlayerStateJump : PlayerState
{
	public PlayerStateJump(Animator animator)
		: base(animator)
    {
        EnableInputHandling(false);
    }
}
