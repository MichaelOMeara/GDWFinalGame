using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerThree : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the door moves upward
    public float moveDistance = 3f; // Distance the door will move upward
    private bool isPlayerNear = false; // Tracks if the player is near the door
    private bool isDoorOpening = false; // Tracks if the door is currently opening
    private Vector3 initialPosition; // The starting position of the door
    private Vector3 targetPosition; // The position to which the door will move

    private BoxCollider2D solidCollider; // Non-trigger collider for blocking the player
    private BoxCollider2D triggerCollider; // Trigger collider for detecting the player

    public string correctCode = "8765"; // The correct code to open the door
    private string currentInput = ""; // Player's current input

    void Start()
    {
        // Store the initial position and calculate the target position
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(0, moveDistance, 0);

        // Get the colliders attached to the door
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D collider in colliders)
        {
            if (collider.isTrigger)
                triggerCollider = collider; // Assign the trigger collider
            else
                solidCollider = collider; // Assign the solid collider
        }
    }

    void Update()
    {
        // Check if the player is near and interacting
        if (isPlayerNear)
        {
            foreach (char c in Input.inputString) // Capture player's numeric input
            {
                if (char.IsDigit(c))
                {
                    currentInput += c;
                    Debug.Log("Current Input: " + currentInput);

                    // If the input matches the correct code, open the door
                    if (currentInput == correctCode)
                    {
                        Debug.Log("Code accepted! Door opening...");
                        isDoorOpening = true;
                        currentInput = ""; // Reset input
                    }

                    // Limit input length to the code length
                    if (currentInput.Length >= correctCode.Length)
                    {
                        Debug.Log("Incorrect code. Try again.");
                        currentInput = ""; // Reset input
                    }
                }
            }
        }

        // If the door is opening, move it upward
        if (isDoorOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Disable the solid collider when the door is fully open
            if (transform.position == targetPosition)
            {
                isDoorOpening = false;
                solidCollider.enabled = false; // Disable the collider so the player can pass
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            DisplayInteractionPrompt(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            DisplayInteractionPrompt(false);
            currentInput = ""; // Reset input when the player leaves
        }
    }

    void DisplayInteractionPrompt(bool show)
    {
        if (show)
        {
            Debug.Log("Enter the numeric code to open the door.");
        }
        else
        {
            Debug.Log("You are too far to interact with the door.");
        }
    }
}
