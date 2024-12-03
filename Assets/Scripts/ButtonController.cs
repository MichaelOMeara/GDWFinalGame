using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string numericCode = "1234"; // The numeric code to reveal
    private bool canInteract = false; // Determines if the button is active

    void Update()
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
        Debug.Log("Button pressed! Revealing numeric code...");
        RevealCode();
    }

    private void RevealCode()
    {
        Debug.Log($"The numeric code is: {numericCode}");
    }
}
