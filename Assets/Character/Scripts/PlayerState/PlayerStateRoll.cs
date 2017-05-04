using UnityEngine;
using System.Collections.Generic;

class PlayerStateRoll : PlayerState
{
    float timeLeft;

	public PlayerStateRoll(Animator animator)
		: base(animator)
    {
        timeLeft = Constants.ROLL_TIME;
    }

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        if ((timeLeft -= Time.deltaTime) > 0f)
            return;

		if (input.Contains(KeyPress.MoveRight))
        {
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceRight(_animator);
            timeLeft = Constants.ROLL_TIME;
        }
		else if (input.Contains(KeyPress.MoveLeft))
        {
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceLeft(_animator);
            timeLeft = Constants.ROLL_TIME;
        }
		else
        {
            ChangeState(PlayerStateEnum.TestIdle);
            timeLeft = Constants.ROLL_TIME;
        }
    }
}
