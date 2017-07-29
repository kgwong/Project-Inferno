public static class Constants
{
	public const int BASE_MOVE_SPEED = 100;
	public const int BASE_JUMP_SPEED = 300;
    public const int BASE_ROLL_SPEED = 100;
    public const float ROLL_TIME = 1f;
    public const float PLAYER_STAMINA_CHARGE_TIME = .3f;

    public static int GetStaminaCost(PlayerStateEnum state)
    {
        switch (state)
        {
            case PlayerStateEnum.TestHighAttack:
            //case PlayerStateEnum.TestHighAttackCombo:
            case PlayerStateEnum.TestMidAttack:
            case PlayerStateEnum.TestMidAttackCombo:
            case PlayerStateEnum.TestLowAttack:
            //case PlayerStateEnum.TestLowAttackCombo:
            case PlayerStateEnum.TestRoll:
                return 25;
            default:
                return 0;
        }
    }
}
