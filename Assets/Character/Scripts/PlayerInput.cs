using UnityEngine;

public static class PlayerInput
{
    public static bool PressedRoll()
    {
        return Input.GetKeyDown(KeyCode.C);
    }

    public static bool PressedMidAttack()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public static bool PressedJump()
    {
        return Input.GetKey(KeyCode.B);
    }
    public static bool PressedMoveLeft()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }
    public static bool PressedMoveRight()
    {
        return Input.GetKeyDown(KeyCode.RightArrow);
    }

	public static bool HoldingMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public static bool HoldingMoveRight()
    {
       return Input.GetKey(KeyCode.RightArrow);
    }    

    public static bool PressedHighAttack()
    {
        return Input.GetKeyDown(KeyCode.S);
    }
}
