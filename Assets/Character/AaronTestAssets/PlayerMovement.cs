//The original code used for player states -> trashed for the __State files





//using UnityEngine;
//using System.Collections;


//public class PlayerMovement : MonoBehaviour {


//    public float move_speed = 3f;
//    public float jump_power = 8f;
//    public float roll_speed = 5f;
//    public float roll_time = 2f;


//    private Animator animator;
//    private Rigidbody2D rb;
//    private int directionFacing = 1;
//    //private ArrayList lockStates = new ArrayList();
//    private Vector3 scale;
//    private float timer;
//    private BoxCollider2D bc;
//    private SpriteRenderer sr;
//    //private float heightDifference = (float)0.65;
//    private RaycastHit2D downRay;
//    public OnGround og;

//    void Start() {


//        animator = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//        scale = transform.localScale;
//        bc = GetComponent<BoxCollider2D>();
//        sr = GetComponent<SpriteRenderer>();
//        og = GetComponent<OnGround>();
       


//    }

//   void FixedUpdate() {
        
//        bc.size = sr.bounds.size;
//        if (!animator.GetBool("Rolling"))
//        {
//            //horizontal movement
//            float horizontal = Input.GetAxis("Horizontal");
//            rb.AddForce(Vector2.right * horizontal * move_speed, ForceMode2D.Impulse);



//                if (horizontal != 0 && og.checkGrounded())
//                {
//                    animator.Play("Walk");
//                    Flip(horizontal);
//                }

//                else 
//                {
//                    animator.Play("Idle");
//                }

//                if (Input.GetKeyDown(KeyCode.Space) && og.checkGrounded())
//                {
//                    animator.Play("Jump");
//                    rb.AddForce(Vector2.up * jump_power, ForceMode2D.Impulse);

//                }

//                if (Input.GetKeyDown(KeyCode.X))
//                {
//                    animator.SetBool("OnGround", false);
//                    animator.SetBool("Rolling", true);
//                    timer = Time.time;
//                }

//         }
//        else
//        {
//            float timePassed = Time.time - timer;
//            if (timePassed < roll_time)
//            {
//                animator.Play("Roll");
//                Flip(directionFacing);
//                rb.AddForce(new Vector2(roll_speed * directionFacing, 0), ForceMode2D.Impulse);
//            }
//            else
//            {
//                animator.SetBool("Rolling", false);
//            }
//        }
//    }



//    void Flip(float horizontal)
//    {
//        if ((directionFacing == 1 && horizontal < 0) || (directionFacing == -1 && horizontal > 0))
//        {
//            scale.x *= -1;
//            transform.localScale = scale;

//            directionFacing = (int)(horizontal / Mathf.Abs(horizontal));

//        }   
//    }




//    //void OnCollisionExit2D(Collision2D coll)
//    //{
//    //    if(coll.gameObject.tag == "Platform")
//    //    {
//    //        animator.SetBool("OnGround", false);
//    //    }
//    //}

    
//}
