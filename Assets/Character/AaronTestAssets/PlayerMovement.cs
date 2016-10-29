using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {


    public float move_speed = 3f;
    public float jump_power = 8f;
    public float roll_speed = 5f;
    public float roll_time = 0.5f;


    private Animator animator;
    private Rigidbody2D rigidbody;
    private int directionFacing = 1;
    //private ArrayList lockStates = new ArrayList();
    private AnimatorStateInfo stateInfo;
    private Vector3 scale;
    private float timer;
	

	void Start () {

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
       // lockStates.Add();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        scale = transform.localScale;

    }
	
	void FixedUpdate () {
        if (!animator.GetBool("Rolling"))
        {

            float horizontal = Input.GetAxis("Horizontal");

            //position based
           // transform.position += new Vector3(horizontal, 0, 0) * move_speed * Time.deltaTime;

            //add force
            rigidbody.AddForce(Vector2.right * horizontal * move_speed, ForceMode2D.Impulse);

                if (animator.GetBool("OnGround"))
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

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        animator.SetBool("OnGround", false);
                        animator.Play("Jump");
                        rigidbody.AddForce(Vector2.up * jump_power, ForceMode2D.Impulse);
                    }

                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        animator.SetBool("OnGround", false);
                        animator.SetBool("Rolling", true);
                        timer = Time.time;
                    }

                }
            }
        else 
        {
            float timePassed = Time.time-timer;
            print(timePassed);
            if (timePassed < roll_time)
            {
                animator.Play("Roll");
                Flip(directionFacing);
                rigidbody.AddForce(new Vector2(roll_speed * directionFacing, 0), ForceMode2D.Impulse);
                print("adding force");
            }
            else
            {
                animator.SetBool("OnGround", true);
                animator.SetBool("Rolling", false);
            }
        }
    }

    void Flip(float horizontal)
    {
        if ((directionFacing == 1 && horizontal < 0) || (directionFacing == -1 && horizontal > 0))
        {
            scale.x *= -1;
            transform.localScale = scale;

            directionFacing = (int)(horizontal / Mathf.Abs(horizontal));

        }   
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        //maybe add a bit of space above the ground to be considered OnGround
        //attempting to jump slightly before you actually hit the ground and failing feels bad
        if(coll.gameObject.tag == "Platform")
        {
            animator.SetBool("OnGround", true);
        }
    }
}
