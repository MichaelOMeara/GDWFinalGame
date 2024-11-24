using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f; // The speed at which the GameObject moves (adjust as needed)

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Ensure only horizontal movement occurs, with vertical locked by Rigidbody2D settings
        Vector2 currentPosition = rb.position;
        currentPosition.x += moveSpeed * Time.fixedDeltaTime; // Move rightward at the constant speed

        rb.MovePosition(currentPosition); // Apply the updated position to the Rigidbody2D
    }

    // Detect when the moving object enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Destroy the player object
            Destroy(other.gameObject);
        }
    }
}