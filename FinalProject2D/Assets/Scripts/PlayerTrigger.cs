using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player")))
        {
            Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            // Prevents the cube from rotating from collisions
            //Debug.Log("Whasss");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.CompareTag("Player"));
        if (!(collision.CompareTag("Player")))
        {
            Player.GetComponent<Player>().isInAir = false;
        }
        //Debug.Log(player.GetComponent<Player>().isInAir);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player")))
        {
            Player.GetComponent<Player>().isInAir = true;
        }
        //Debug.Log(player.GetComponent<Player>().isInAir);
        //player.GetComponent<Player>().isInAir = true;
    }

    // ! ! ! THE ULTIMATE SOLUTION ! ! !
    /* The Hitbox should have a rigidbody & a collider attached to it.
     * in the RB component, freeze the Z-axis, which will prevent collisions from causing
     * unnecessary rotations.
     * The Hitbox should only move up and down when the jump button is pressed.
     * The Hitbox WILL NOT rotate while it is in the air, the visible cube will rotate.
     * The Hitbox should appear invisible to the player, yet still retain its collision functionality (alpha key it).
     * The Hitbox will function as a collider.
     * Have the visible cube follow the hitbox, and not the other way around. The visible cube should not have a RB
     * nor a collider. It is intended that this cube is just a sprite that visually
     * represent's its hitbox.
     * Without a RB, the visible cube will not be affected by gravity, and therefore,
     * it will not fall through the ground nor will it attempt to collide with any blocks or obstacles.
     * Rather, the cube will phase through it-like in Geometry Dash-until its HITBOX reaches and collides with
     * the obstacle.
    */
}
