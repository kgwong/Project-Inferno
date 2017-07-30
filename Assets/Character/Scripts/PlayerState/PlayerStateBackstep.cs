using UnityEngine;
using System.Collections;

class PlayerStateBackstep : PlayerState {
    float timeLeft;

    public PlayerStateBackstep(Animator animator)
		: base(animator)
    {
        timeLeft = Constants.BACKSTEP_TIME;
    }

    public override void Update () {
        if ((timeLeft -= Time.deltaTime) > 0f)
            return;

        if (PlayerInput.PressedMoveRight())
        {
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceRight(_animator);
            timeLeft = Constants.BACKSTEP_TIME;
        }
        else if (PlayerInput.PressedMoveLeft())
        {
            ChangeState(PlayerStateEnum.TestMove);
            AnimatorCommon.FaceLeft(_animator);
            timeLeft = Constants.BACKSTEP_TIME;
        }
        else
        {
            ChangeState(PlayerStateEnum.TestIdle);
            timeLeft = Constants.BACKSTEP_TIME;
        }
    }
}
