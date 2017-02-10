using UnityEngine;
using System.Collections;

public class DirectionChecker : MonoBehaviour {

    private int direction; //left = -1, right = +1
	
	void Start () {

        direction = 0;
	}
	
    public int getDirection()
    {
        print(direction);
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
        }
        return direction;
    }

}
