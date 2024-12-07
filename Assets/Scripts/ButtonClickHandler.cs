using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public NumberCycler numberCycler; // Reference to the NumberCycler script

    private void Update()
    {
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to world position
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the click hits this button
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);
            if (hit != null && hit.transform == this.transform)
            {
                OnButtonClick();
            }
        }
    }

    private void OnButtonClick()
    {
        if (numberCycler != null)
        {
            numberCycler.CycleNumber();
        }
        else
        {
            Debug.LogWarning("NumberCycler reference is not set!");
        }
    }
}
