using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {


    private Vector3 scale;
    private int directionFacing = 1;

    void Start ()
    {
        scale = transform.localScale;
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

    public void Flip(float horizontal)
    {
        if ((directionFacing == 1 && horizontal < 0) || (directionFacing == -1 && horizontal > 0))
        {
            scale.x *= -1;
            transform.localScale = scale;

            directionFacing = (int)(horizontal / Mathf.Abs(horizontal));

        }
    }
}
