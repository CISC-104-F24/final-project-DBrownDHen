using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float jumpPower = 5f;
    Rigidbody2D rb;

    public bool isInAir;

    public float yMaxTest = -1000000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-5.5f, transform.position.y, 0f);
        // Prevents collisions from offsetting the cube from its fixed position on the screen.

        rb.rotation = 0f;

        if (Input.GetKey(KeyCode.Space) && isInAir == false)
        {
            rb.AddForce(new Vector2(0f, 1.0f * jumpPower), ForceMode2D.Impulse);
            isInAir = true;
        }
        
        if (transform.position.y > yMaxTest)
        {
            yMaxTest = transform.position.y;
            // min height (from ground): -2.485001
            // max height (from ground): -0.7096601
        }

        if (isInAir)
        {
            transform.eulerAngles += new Vector3(0f, 0f, -1f);
            // rotates the cube while it's in the air, like in Geometry Dash
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    //    // Prevents the cube from rotating from collisions
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isInAir = false;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isInAir = true;
    //}
}
