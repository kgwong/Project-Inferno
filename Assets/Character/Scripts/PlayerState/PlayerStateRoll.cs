using UnityEngine;

class PlayerStateRoll : PlayerState
{
    float timeLeft;

	public PlayerStateRoll(Animator animator)
		: base(animator)
    {
        timeLeft = Constants.ROLL_TIME;
    }

    public override void Update()
    {
        if ((timeLeft -= Time.deltaTime) > 0f)
            return;

		if (PlayerInput.PressedMoveRight())
        {
            ChangeState(PlayerStateEnum.TestMoveRight);
            AnimatorCommon.FaceRight(_animator);
            timeLeft = Constants.ROLL_TIME;
        }
		else if (PlayerInput.PressedMoveLeft())
        {
            ChangeState(PlayerStateEnum.TestMoveLeft);
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
