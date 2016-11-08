using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour {


    public float move_speed = 3f;
    public float jump_power = 8f;
    public float roll_speed = 5f;
    public float roll_time = 2f;


    private Animator animator;
    private Rigidbody2D rb;
    private int directionFacing = 1;
    //private ArrayList lockStates = new ArrayList();
    private AnimatorStateInfo stateInfo;
    private Vector3 scale;
    private float timer;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private float heightDifference = (float)0.65;
    private float groundDistance;
    private int groundLayer;
    private RaycastHit2D downRay;

    void Start() {


        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        scale = transform.localScale;
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        groundDistance = 0.25f;
        groundLayer = 1 << 8;


    }

    void FixedUpdate() {

        downRay = Physics2D.Raycast(sr.bounds.center + Vector3.down * sr.bounds.size.y / 2, Vector3.down, groundDistance, groundLayer);
        bc.size = sr.bounds.size;
        checkBottom();
        if (!animator.GetBool("Rolling"))
        {
            //horizontal movement
            float horizontal = Input.GetAxis("Horizontal");
            rb.AddForce(Vector2.right * horizontal * move_speed, ForceMode2D.Impulse);



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

                if (Input.GetKeyDown(KeyCode.Space) && downRay.distance < 0.019)
                {
                    animator.SetBool("OnGround", false);
                    animator.Play("Jump");
                    rb.AddForce(Vector2.up * jump_power, ForceMode2D.Impulse);

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
            float timePassed = Time.time - timer;
            if (timePassed < roll_time)
            {
                animator.Play("Roll");
                Flip(directionFacing);
                rb.AddForce(new Vector2(roll_speed * directionFacing, 0), ForceMode2D.Impulse);
            }
            else
            {
                animator.SetBool("OnGround", true);
                animator.SetBool("Rolling", false);
            }
        }
    }

    //use raycasting to determine OnGround
    //jump "fails" if pressed during the window when you're not touching the ground yet but already "OnGround",
    //but input queue should fix this
    void checkBottom()
    {
        print(downRay.distance);
        if (rb.velocity.y < 0 && downRay.collider != null)
        {
            animator.SetBool("OnGround", true);
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




    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform")
        {
            animator.SetBool("OnGround", false);
        }
    }

    
}
