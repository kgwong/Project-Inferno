using UnityEngine;
using System.Collections;

public class DirectionChecker : MonoBehaviour {

    private Vector2 previousPos;
    private int direction; //left = -1, right = +1
	
	void Start () {
        previousPos = transform.position;
        direction = 1;
	}
	
    public int getDirection()
    {
        return direction;
    }



	void FixedUpdate () {

        if (transform.position.x > previousPos.x)
        {
            direction = 1;
        }
        else if (transform.position.x < previousPos.x)
        {
            direction = -1;
        }

        if (transform.position.x != previousPos.x)
        {
            previousPos = transform.position;
        }
 
	}
}
