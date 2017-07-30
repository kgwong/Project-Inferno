using UnityEngine;

class PlayerStateMidCombo : PlayerState
{
    public PlayerStateMidCombo(Animator animator)
        : base(animator)
    {
        EnableInputHandling(false);
    }
}
