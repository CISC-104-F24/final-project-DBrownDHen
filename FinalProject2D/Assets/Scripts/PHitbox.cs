using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHitbox : MonoBehaviour
{
    public float jumpPower = 3f;
    Rigidbody2D rb;
    public bool isInAir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isInAir == false)
        {
            rb.AddForce(new Vector2(0f, 1.0f * jumpPower), ForceMode2D.Impulse);
            isInAir = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isInAir = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isInAir = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isInAir = true;
    }
}
