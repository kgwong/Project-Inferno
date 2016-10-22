using UnityEngine;
using System.Collections;



public class Player : MonoBehaviour {


    public float speed = 2f;
    private Animator animator;
    private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
       // if (animator.)
	
	}
	
	// Update is called once per frame
	void Update () {
        int horizontal = 0;
        

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
        if (horizontal > 0 && animator.GetBool("OnGround"))
        {
            animator.Play("WalkRight");
        }

        else if (horizontal < 0 && animator.GetBool("OnGround"))
        {
            animator.Play("WalkLeft");
        }

        else { }

        if (Input.GetKeyDown("space") && animator.GetBool("OnGround"))
        {
            animator.SetBool("OnGround", false);
            animator.Play("Jump");
            rigidbody.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
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
