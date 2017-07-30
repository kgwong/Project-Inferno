using UnityEngine;
using System.Collections;

public class MonsterJump : MonoBehaviour
{
    public float jumpVelocity;
    public float xVelocity;
    private bool canJump;  //just in case we want double jump/flying enemies
    private bool touchingFloor;
    private Rigidbody2D rb;
    public Collision2D obj;

	//Currently, all this will do is make the monster jump
    //nonstop.

    // Use this for initialization
	void Start ()
    {
        canJump = true;
        touchingFloor = true;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if(canJump && touchingFloor)
        {
            rb.AddForce(Vector2.left * Direction(-xVelocity, xVelocity));
            rb.AddForce(Vector2.up * jumpVelocity);
            canJump = false;
            touchingFloor = false;
        }
	}


    void OnCollisionEnter2D(Collision2D obj)
    {
        //Find a way where once it stops touching the floor
        //change touchingFloor to false.
        //could just be else touchingFloor = false;
        
        if (obj.gameObject.tag == "Terrain")
        {
            //print("touch");
            touchingFloor = true;
            canJump = true;
        }
        
        //Debug.Log(obj.gameObject.name);
    }

    float Direction(float minNum, float maxNum)
    {
        return Random.Range(minNum, maxNum);
    }
}
