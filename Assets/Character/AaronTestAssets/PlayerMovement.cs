using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {


    public float speed = 2f;
    public float jump = 8f;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private bool isFacingRight = true;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        // if (animator.)

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = (Input.GetAxis("Horizontal"));

        //position based
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        //add force
        //rigidbody.AddForce(new Vector2(horizontal * speed, 0), ForceMode2D.Force);

        if(animator.GetBool("OnGround"))
        {
            if (horizontal != 0)
            {

                animator.Play("Walk");
                Flip(horizontal);
            }
            else
            {
                animator.Play("Idle");
            }
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("OnGround", false);
                animator.Play("Jump");
                rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }
        }


    }

    void Flip(float horizontal)
    {
        if ((isFacingRight && horizontal < 0) || (!isFacingRight && horizontal > 0))
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            if (horizontal > 0)
            {
                isFacingRight = true;
            }

            if (horizontal < 0)
            {
                isFacingRight = false;
            }
        }   
    }


    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag == "Platform")
        {
            animator.SetBool("OnGround", true);
        }
    }
}
