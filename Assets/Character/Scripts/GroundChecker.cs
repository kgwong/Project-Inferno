﻿using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{

    void Start()
    {
    }

    public bool OnGround(Collider2D downCollider)
    {
        RaycastHit2D[] downCast = Physics2D.RaycastAll(transform.position, Vector2.down);
        //int hit = downCollider.Raycast((transform.position), downCast, 2);
        float colliderBottomY = downCollider.bounds.min.y;

        //prevents from running if there is an exception, or if no objects below
        //downCast[0] should be the first object the ray cast hits. If it is the ground, check the distance from it.
        if (downCast.Length > 0)
        {
            if (downCast[0].collider.tag == "Terrain")
            {
                float groundTopY = downCast[0].collider.bounds.max.y + 0.1f;
                return colliderBottomY - groundTopY <= 0.05f;
            }
        }
        return false;
    }



}

