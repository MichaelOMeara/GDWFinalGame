using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMovement : MonoBehaviour
{
    public float normalSpeed = 0.3f;   // Default movement speed
    public float maxSpeed = 2.0f;     // Maximum movement speed when far from the player
    public float speedIncreaseRange = 5.0f; // Distance at which the speed starts increasing
    public float returnToNormalRange = 2.0f; // Distance at which the speed returns to normal
    public Transform player;          // Reference to the player's Transform

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();

        // Find the player if not explicitly assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (player == null) return; // Exit if the player is not found

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Adjust the speed based on the distance
        float currentSpeed = normalSpeed;
        if (distanceToPlayer > returnToNormalRange)
        {
            currentSpeed = Mathf.Lerp(normalSpeed, maxSpeed, (distanceToPlayer - returnToNormalRange) / (speedIncreaseRange - returnToNormalRange));
        }

        // Ensure the speed stays within bounds
        currentSpeed = Mathf.Clamp(currentSpeed, normalSpeed, maxSpeed);

        // Move the object horizontally at the calculated speed
        Vector2 currentPosition = rb.position;
        currentPosition.x += currentSpeed * Time.fixedDeltaTime; // Move rightward at the calculated speed

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