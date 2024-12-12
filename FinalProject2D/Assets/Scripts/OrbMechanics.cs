using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMechanics : MonoBehaviour
{

    public bool hasBeenUsed;
    public bool isColliding;
    public float jumpBoost = 3.5f;
    public GameObject BoostedObject;
    private Rigidbody2D borb;
    public float boostTimer;
    public bool spacePressed;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenUsed = false;
        borb = BoostedObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boostTimer = 0.25f;
        }

        if (!(boostTimer <= 0))
        {
            spacePressed = true;
            boostTimer -= 1.0f * Time.deltaTime;
        }
        else
        {
            spacePressed = false;
        }

        if (spacePressed == true && hasBeenUsed == false && isColliding == true)
        {
            hasBeenUsed = true;
            boostTimer = 0.0f;
            spacePressed = false;
            borb.velocity = new Vector3(0f, (jumpBoost * 2.0f) - 0.2943f, 0f);
            //borb.AddForce(new Vector2(0f, 1.0f * jumpBoost), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            borb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    isColliding = true;
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isColliding = true;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isColliding = false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
