using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public float rotationsNeeded = 3; // Number of full rotations required to trigger the next phase
    private float currentRotation = 0f; // Tracks the current rotation
    private float totalRotations = 0f; // Tracks total rotations completed
    private bool isDragging = false; // Whether the lever is being dragged
    private Vector3 initialMousePosition; // Initial mouse position for drag calculation
    public SwitchController switchController;

    void Update()
    {
        // Handle mouse interaction
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            // Check if the mouse is over the lever
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

            if (hit != null && hit.transform == this.transform)
            {
                isDragging = true;
                initialMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            RotateLever();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Check if the required rotations are completed
        if (totalRotations >= rotationsNeeded)
        {
            TriggerNextPhase();
        }
    }

    void RotateLever()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 deltaMouse = currentMousePosition - initialMousePosition;

        // Determine rotation based on horizontal drag
        float rotationAmount = deltaMouse.x * 0.2f; // Adjust sensitivity as needed
        transform.Rotate(0, 0, -rotationAmount); // Rotate lever
        currentRotation += Mathf.Abs(rotationAmount);

        // Update total rotations if a full 360-degree rotation is completed
        if (currentRotation >= 360f)
        {
            totalRotations += 1;
            currentRotation -= 360f; // Reset current rotation
            Debug.Log($"Rotations completed: {totalRotations}");
        }

        initialMousePosition = currentMousePosition; // Update initial position for smooth dragging
    }

    void TriggerNextPhase()
    {
        Debug.Log("Lever rotation complete! Activating switch...");
        switchController.ActivateSwitch(); // Activate the switch
    }
}
