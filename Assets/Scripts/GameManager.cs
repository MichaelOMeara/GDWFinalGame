using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText; // Reference to the "Game Over" Text
    public Button Reset; // Reference to the Reset Button

    private void Start()
    {
        // Ensure "Game Over" text and Reset button are hidden initially
        GameOverText.gameObject.SetActive(false);
        Reset.gameObject.SetActive(false);

        // Attach the ResetScene method to the button's OnClick event
        Reset.onClick.AddListener(ResetScene);
    }

    public void PlayerDestroyed()
    {
        // Show the "Game Over" text and Reset button
        GameOverText.gameObject.SetActive(true);
        Reset.gameObject.SetActive(true);
    }

    public void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
