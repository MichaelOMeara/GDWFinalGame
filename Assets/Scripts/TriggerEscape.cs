using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerEscape : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; // Assign the player's Rigidbody2D
    public TextMeshProUGUI escapeText;  // TextMeshPro for "You've Escaped!"
    public Button resetButton;          // UI Button to reset the scene

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Disable gravity for the player
            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale = 0; // Completely disable gravity
                playerRigidbody.velocity = Vector2.zero; // Stop all vertical and horizontal movement
                playerRigidbody.bodyType = RigidbodyType2D.Kinematic; // Prevent additional physics forces
            }

            // Show the escape text
            if (escapeText != null)
            {
                escapeText.gameObject.SetActive(true);
            }

            // Show the reset button
            if (resetButton != null)
            {
                resetButton.gameObject.SetActive(true);

                // Add functionality to the reset button
                resetButton.onClick.AddListener(ResetScene);
            }
        }
    }

    private void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}