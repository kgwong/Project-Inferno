using UnityEngine;
using System.Collections.Generic;

public static class PlayerInput
{
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
