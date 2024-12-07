using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject codePrefab; // The prefab containing the SpriteRenderer
    private GameObject instantiatedCode; // Reference to the instantiated code object
    private bool canInteract = false; // Determines if the button is active

    private void Update()
    {
        // Check for mouse click and interaction
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

            if (hit != null && hit.transform == this.transform)
            {
                OnButtonPress();
            }
        }
    }

    public void ActivateButton()
    {
        canInteract = true; // Allow interaction with the button
        Debug.Log("Button activated. You can now press it.");
    }

    private void OnButtonPress()
    {
        Debug.Log("Button pressed! Displaying numeric code...");
        DisplayCode();
    }

    private void DisplayCode()
    {
        // Instantiate the prefab at a specific position
        Vector3 spawnPosition = new Vector3(11, 2, 0); // Adjust as needed
        instantiatedCode = Instantiate(codePrefab, spawnPosition, Quaternion.identity);

        // Destroy the instantiated prefab after 10 seconds
        Destroy(instantiatedCode, 10f);
    }
}
