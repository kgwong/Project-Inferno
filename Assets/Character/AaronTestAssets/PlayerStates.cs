﻿using UnityEngine;
using System.Collections;

public class PlayerStates : MonoBehaviour {


    private Vector3 scale;
    public float direction = 1; //right = 1, left = -1
    public int facing = 1;
    protected bool grounded = false;
    protected new string name;
    protected SpriteRenderer sr;


    //this doesn't appear to do anything...
    void Start ()
    {
        //sr = gameObject.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    public virtual void Update ()
    {
    }

    public virtual void ComponentUpdate()
    {

    }

    public virtual void handleInput()
    {

    }

    public void Flip()
    {


        if (facing > 0 && direction < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            facing = -1;
        }
        if(facing < 0 && direction > 0)
        {
            facing = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }

    public void setDirection(float d)
    {
        direction = d;
    }

    public float getDirection()
    {
        return direction;
    }

    public void setGrounded(bool g)
    {
        grounded = g;
    }
}