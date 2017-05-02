using UnityEngine;
using System.Collections.Generic;

class PlayerStateAttackSkeleton : PlayerState
{
    public PlayerStateAttackSkeleton(Animator animator)
        : base(animator)
    {
        
    }

    protected override void HandleInput(HashSet<KeyPress> input)
    {
        /*
        To add an attack state:
        1. Create a new state in the state machine, with an animation
        2. Add new entry to PlayerStateEnum
            a. use the smallest positive int available
            b. i.e. if the highest number taken is 9, use 10
        3. Add transitions in the state machine to this state
            a. from Idle/last in combo/etc using the unique int
            b. to idle/next in combo/etc using the unique int
            c. Most attack states probably need exit time(although its up to you)
        4. Copy this class with a new name
            a. Change class name appropriately
            b. Change filename appropriately
        5. Add button handling in prior states
            a. E.g. in Idle's update(), add "else if (PlayerPushedX){ChangeState(newState);}"
        6. In this update, handle button presses to next states(idle, next in combo, etc)
        7. Be sure to leave some way out of the state, else you'll loop it forever
            a. eg base.Update() will immediately transition to TestIdle, making testIdle handle input
            b. eg IdleIfFinished() will switch to idle when animation is over, allowing your state
               to continue handling input
        */

        if (PlayerInput.PressedMidAttack())
        {
            ChangeState(PlayerStateEnum.TestMidAttack);
        }
    }
}
