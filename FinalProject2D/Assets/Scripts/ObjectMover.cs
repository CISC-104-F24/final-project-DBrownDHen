using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject CubeHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO
        // As long as the cube has not crashed...
        // move object towards the left of the screen.

        // If the cube has crashed...
        // ease object movement out to a stop.
        // It is intended for another script to prompt the user to restart the level, not this script.
        
        // make a boolean variable that scripts can use to determine if the cube has crashed.
        // this will be used to stop movement of level objects (in this script), and prompt the
        // user to restart the level, and possibly other things.

        if (!(CubeHitbox.GetComponent<PHitbox>().isAlive))
        {
            if (moveSpeed <= 0.0f)
            {
                moveSpeed = 0.0f;
            }
            else
            {
                moveSpeed -= 3.0f * Time.deltaTime;
            }
        }
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
