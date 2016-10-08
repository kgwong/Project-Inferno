public static class Constants
{
    public static int STATE_IDLE { get { return 0; } }
    public static int STATE_MOVE_LEFT { get { return 1; } }
    public static int STATE_MOVE_RIGHT { get { return 2; } }
    public static int STATE_ROLL { get { return 3; } }
    public static int STATE_MID_ATTACK { get { return 4; } }
    public static int STATE_MID_COMBO { get { return 5; } }
    public static int STATE_JUMP { get { return 6; } }

	public static int BASE_MOVE_SPEED { get { return 100; } }
	public static int BASE_JUMP_SPEED { get { return 250; } }
}