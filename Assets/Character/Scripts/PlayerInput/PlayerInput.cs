using UnityEngine;
using System.Collections.Generic;

public static class PlayerInput
{
    // Deprecated, remove later(aka after no horrible bugs)
    public static bool PressedRoll()
    {
        return Input.GetButton("Roll");
    }

    public static bool PressedMidAttack()
    {
        return Input.GetButton("Fire1");
    }

    public static bool PressedJump()
    {
        return Input.GetButton("Jump");
    }
    public static bool PressedMoveLeft()
    {
        return Input.GetAxis("Horizontal") > 0;
    }
    public static bool PressedMoveRight()
    {
        return Input.GetAxis("Horizontal") < 0;
    }

	public static bool HoldingMoveLeft()
    {
        return PressedMoveLeft();
    }

    public static bool HoldingMoveRight()
    {
       return PressedMoveRight();
    }    

    // New Stuff

    public static HashSet<KeyPress> GetInput()
    {
        HashSet<KeyPress> result = new HashSet<KeyPress>();
        foreach (KeyPress k in System.Enum.GetValues(typeof(KeyPress)))
        {
            if (Pressed(k))
            {
                result.Add(k);    
            }
        }

        return (result.Count == 0) ? null : result;
    }

    private static bool Pressed(KeyPress k)
    {
        if (k == KeyPress.MoveLeft || k == KeyPress.MoveRight)
        {
            return Input.GetButton(k.ToString());
        }
        else
        {
            return Input.GetButtonDown(k.ToString());
        }
    }
}
