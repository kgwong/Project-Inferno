using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {

    public float hp = 100f;
    public float damage = 50f;
    public GameObject bullet;
    public Transform firingPosition;

    private GameObject player;
    //private Rigidbody2D self;
    private float distance;
    private bool knockback;
    private float waitTimer = 0f;
    private bool attackWait = false;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.GetChild(0);
        //self = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (attackWait == true)
        {
            waitTimer += Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        distance = transform.position.x - player.transform.position.x;

        if (distance < 15 & attackWait == false)
        {
            Instantiate(bullet, firingPosition.position, firingPosition.rotation);
            attackWait = true;
        }

        else if (distance < 15 & attackWait == true & waitTimer > 0.8f)
        {
            attackWait = false;
            waitTimer = 0f;
        }

    }

}
