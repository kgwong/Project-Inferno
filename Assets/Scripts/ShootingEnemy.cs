using UnityEngine;
using System.Collections;

public class ShootingEnemy : MonoBehaviour {

    public float hp = 100f;
    public float damage = 50f;
    public GameObject bullet;
    public Transform firingPosition;

    private GameObject player;
    private float waitTimer = 0f;
    private bool attackWait = false;
    private float waitTime = 0.8f;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update ()
    {
        if (attackWait)
        {
            waitTimer += Time.deltaTime;
        }
	}

    void FixedUpdate()
    {
        float distance = transform.position.x - player.transform.position.x;

        if (distance < 15 & !attackWait)
        {
            Instantiate(bullet, firingPosition.position, firingPosition.rotation);
            attackWait = true;
        }

        else if (distance < 15 & attackWait & waitTimer > waitTime)
        {
            attackWait = false;
            waitTimer = 0f;
        }

    }

}
