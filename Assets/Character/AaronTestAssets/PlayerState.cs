using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {


    private Vector3 scale;
    protected float direction = 1;
    protected int facing = 1;
    private SpriteRenderer sr;
    void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
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
        Debug.Log(gameObject);

        Debug.Log("FACING: " + facing);

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
}
