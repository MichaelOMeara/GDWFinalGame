using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset; // Optional offset to adjust the camera's position relative to the player

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
    }
}

