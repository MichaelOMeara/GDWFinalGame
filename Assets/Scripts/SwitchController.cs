using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite offSprite; // Sprite for the "off" state
    public Sprite onSprite;  // Sprite for the "on" state
    private SpriteRenderer spriteRenderer;

    private bool isOn = false; // Current state of the switch
    private bool canInteract = false; // Determines if the switch is active
    public ButtonController buttonController;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = offSprite; // Start with the "off" sprite
    }

    void Update()
    {
        // Check for mouse click and interaction
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPosition);

            if (hit != null && hit.transform == this.transform)
            {
                ToggleSwitch();
            }
        }
    }

    public void ActivateSwitch()
    {
        canInteract = true; // Allow interaction with the switch
        Debug.Log("Switch activated. You can now toggle it.");
    }

    private void ToggleSwitch()
    {
        isOn = !isOn; // Toggle the state
        spriteRenderer.sprite = isOn ? onSprite : offSprite; // Change the sprite
        Debug.Log(isOn ? "Switch turned ON" : "Switch turned OFF");

        // Optional: Trigger the next phase if required
        if (isOn)
        {
            TriggerNextPhase();
        }
    }

    private void TriggerNextPhase()
    {
        Debug.Log("Switch flipped ON! Activating button...");
        buttonController.ActivateButton(); // Activate the button
    }
}
