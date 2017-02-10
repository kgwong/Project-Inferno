using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{

    public float jumpSpeed;
    private bool jumpAvailable;
    Rigidbody2D rb;
    Animator anim;
    GroundChecker checkGround;
    Collider2D collider;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkGround = GetComponent<GroundChecker>();
        collider = GetComponent<Collider2D>();
        jumpAvailable = true;
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        bool touchingGround = checkGround.OnGround(collider);

        if (touchingGround && jumpAvailable)
        {

            if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("roll") == false)
            {
                print(touchingGround);
                print("jumping up");
                anim.SetBool("jump", true);
                rb.AddForce(Vector2.up * jumpSpeed);

            }
        }
        else if (!jumpAvailable && touchingGround)
        {

            print("landing");
            anim.SetBool("jump", false);
            jumpAvailable = true;

        }
        else if (jumpAvailable && !touchingGround)
        {
            jumpAvailable = false;
            print("in air");
            anim.SetBool("jump", true);
        }

    }

  

}