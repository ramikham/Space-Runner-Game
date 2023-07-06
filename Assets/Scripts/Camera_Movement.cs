using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class to control the movement and the placement of the camera,
 */
public class Camera_Movement : MonoBehaviour
{
    public Transform player_transform;           // A reference to the player's position 
    public Vector3 camera_position_offset = new Vector3(0, 1.5f, -5);      // An offset (with respect to the Player) to position the camera at

    // Update is called once per frame
    void Update()
    {
        transform.position = player_transform.position + camera_position_offset;
    }
}
