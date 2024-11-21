using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCube : MonoBehaviour
{

    public GameObject CubeHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // add rotation acceleration. Rotation accelerates up to -0.5f over the course of a second or something.

        transform.position = CubeHitbox.transform.position;
        if (CubeHitbox.GetComponent<PHitbox>().isInAir)
        {
            transform.eulerAngles += new Vector3(0f, 0f, -0.5f);
            // rotates the cube while it's in the air, like in Geometry Dash
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            // as a temporary measure, this will straighten up the cube when it lands
            // on the ground. Later, work on alignment of the cube itself as described below.

            AlignCube();
        }
    }

    private void AlignCube()
    {
        //float test = transform.rotation.eulerAngles.z;
        //int intValue = (int)Math.Round(floatValue);

        // if cube's rotation is between 0 and -90...

        // if cube's rotation is between -90 and -180...

        // if cube's rotation is between -180 and -270...

        // if cube's rotation is between -270 and -360...

        // the rotation follows as such...
        // always rotates clockwise, starts at 0. 
        // decreases down to -180
        // upon reaching 180, rotation switches to positive 180
        // rotation continues to decrease from 180 down to 0
        // sequence repeats.

        /* Therefore
         * 0 - Top of cube facing upright and normal    ^
         * -90 - Top of cube facing right               ->
         * 180 - Top of cube facing downwards           \/
         * 90 - Top of cube facing left                 <-
         */
    }

    // When the cube returns to the ground, it is intended that it is rotated 
    // to align with one of the 4 directional axis: 0, 90, 180, 270
    // alignment should depend on whichever direction the cube's rotation is closer to.
    // So, for example, if the cube reaches the ground, and its rotation is a value between 90 and 180,
    // the code in the script will have to determine if the cube should be shifted to either a 90 degree rotation or a 180 degree roation,
    // depending on whichever value the cube's current rotation is closer to.

    // so, if the cube's rotation is 136 degrees, it is closer to 180, so it should be aligned to 180 degrees.
    // In contrast, if the cube's rotation is 134 degrees, it is closer ot 90, so it should be aligned to 90 degrees.

    // What about 135? That is the median between 90 and 180. 
    // In this case, the degree at which the cube aligns to will depend on which direction it is rotating.
    // If the cube is rotating clockwise (negative degrees diection) and alignment occurs when the cube is at a -135 degree rotation, then
    // the cube should be aligned to -180 degrees since, on a physics standpoint, the cube was rotating more towards -180.

    // This should also work in the other direction: 0, -90, -180, -270
    // Therefore, the cube's rotation should exceed the bounds of -360 and 360.
    // Technically, this would still be possible to do if it did, but it would be much harder because the rotation can be infinite.
    // Therefore, you would have to take into account any and all coterminal angles associated with the 4 directional axis.

    /*
     * -360     -315        -270
     * -270     -225        -180
     * -180     -135        -90
     * -90      -45         0
     * 0        45          90
     * 90       135         180
     * 180      225         270
     * 270      315         360
    */


    // try to make sure that all these rotational gimmicks do not interfere with the player's ability to jump, since I have been experiencing
    // issues where the player's maximum jump height ends up being inconsistent when the jump buttion is held down.
    // The issue may lie in the fact that the Rigid Body's force system is used to create positive, upwards velocity for the cube, which means it will be accompanied by
    // a negative, downward velocity when Unity's physics system makes the cube return to the ground. I suspect this velocity could have some influence in the force
    // that is generated by the following jump, reducing the height of said jump.

    // In Geometry Dash, jumps-both in a chain and individually-remain very consistent each and every time.
    // Additionally, the game does not follow usual physics because there is no impulse created by falling to the ground. In other words, the player's cube in GD
    // does not bounce after hitting the floor.
    // The game I am making here would be incredibly difficult to play if each jump is not consistent, and I fear that in order to insure this,
    // I may have to reconsider using the Rigid Body system.

    // Unity's RigidBody component is used to ensure that gravity affects the cube and that the cube can return to the ground.
    // However, this system is very advanced, so much so that Unity can keep track of all collisions-big and small-that take place in a game,
    // and it produces results from these collisions that are accurate to real life physics.
    // GD does not follow real life physics to a tee. If you hit the side of a block, you are not pushed by it. Rather, you crash and restart the level.
    // there is a sense of gravity, but landing on one of the edges of a block does not slow you down or try to make you lean and fall off it.
    // Instead, the cube's rotation is corrected into one of four rotational directions, and you keep moving forward.
    // The accuracy of Unity's physics engine could make it difficult to replicate this behavior.
}
