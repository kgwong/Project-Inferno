using UnityEngine;

public static class PlayerInput
{
    public static float PressedRoll() //C
    {
        if (Input.GetButtonDown("Roll") && Input.GetAxis("RjoystickX") != 0)
        {
            float direction = Input.GetAxis("RjoystickX");
            return direction;
        }
        else
        {
            return 0;
        }
        
    }

    public static bool PressedMidAttack() 
    {
        return Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Attack");
    }

    public static bool PressedJump()
    {
        return Input.GetKey(KeyCode.B) || Input.GetButtonDown("Jump");
    }
    public static bool PressedMoveLeft()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow);
    }
    public static bool PressedMoveRight()
    {
        return Input.GetKeyDown(KeyCode.RightArrow) ;
    }

	public static bool HoldingMoveLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("LjoystickX") < 0;
    }

    public static bool HoldingMoveRight()
    {
       return Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("LjoystickX") > 0;
    }    

    public static bool PressedHighAttack()
    {
        return Input.GetKeyDown(KeyCode.S) || (Input.GetAxis("RjoystickY") > 0 && Input.GetButtonDown("Attack"));
    }

    public static bool PressedLowAttack()
    {
        return Input.GetKeyDown(KeyCode.D) || (Input.GetAxis("RjoystickY") < 0 && Input.GetButtonDown("Attack"));
    }

    public static bool PressedBackstep()
    {
        return Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Roll");
    }
}
