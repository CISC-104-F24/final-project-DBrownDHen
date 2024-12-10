using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHitbox : MonoBehaviour
{
    public float jumpPower = 3.5f;
    Rigidbody2D rb;
    public bool isInAir;

    public bool isAlive = true;

    private float testval;

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

        //if (rb.velocity.y > testval)
        //{
        //    testval = rb.velocity.y;
        //}
        //Debug.Log(testval);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crasher"))
        {
            isAlive = false;
        }
    }
    /* TODO
     * Separate the player's hitbox into two different colliders,
     * one for blocks that the cube can land on,
     * one for obstacles that the cube will crash upon colliding with them.
     * 
     * Program a way for these two hitboxes and the rigidbody to differentiate
     * between crashers and colliders.
     * 
     * 
     * In Geometry Dash, the player's cube has two hitboxes:
     * One hitbox is the same size as the cube, and it detects when the cube
     * collides into obstacles that crash the player such as spikes, gears,
     * and thorn bushes.
     * The other hitbox is much smaller, and it only detects when the cube collides
     * into objects that the cube can land on and jump off such as blocks and platforms.
     * 
     * This hitbox has a unique interaction with these objects, though.
     * Like the cube's larger hitbox, it detects when the cube is colliding with another object.
     * The player's cube is able to pass into the hitbox of these objects (bypassing the larger hitbox)
     * UNTIL the cube's smaller hitbox collides with the object's hitbox. When it does, the cube crashes.
     * 
     * Even knowing this, the player's cube is able to land on the top of these objects, so the player's
     * cube is not always capable of passing through these blocks.
     * 
     * Proposed solution: if the height of the player's cube is greater than that of the object it can land on...
     * then the cube can land on the object.
     * Otherwise...
     * The cube can pass through the object until its secondary hitbox collides with the object's hitbox.
     * OR (maybe) until the cube's height is greater.
     * 
     * Other solution: When the primary hitbox (for spikes n stuff) collides with an object the cube can
     * normally land on, and while it is colliding with the object, compare the height of the cube with that of
     * the object. If the object is higher than the cube, temporairly disable the primary hitbox until one of two events occur:
     *      The cube stops colliding with the object
     *      The cube's height surpasses that of the object.
     * 
     * I suspect this will work because the primary hitbox holds the RigidBody component that is responsible for the
     * functionality of all these collision/trigger detection functions. Without it, they wont work.
     * 
     * Effectively, this will roughly mirror the collision/crashing mechanics of Geometry Dash since the player's cube
     * will be able to momentarily pass into the hitbox of a physical object, not crash, and still retain its movement
     * functionality all while Unity's collision physics do not interfere with this behavior.
     * 
     * Obviously, collision physics are still needed in order for the player's cube to jump and land on objects without
     * falling through them. Hopefully, this solution would still allow that to occur while mimicking GD's collision behavior.
    */

}
