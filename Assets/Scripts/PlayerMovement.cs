using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for left and right movement
    public float jumpForce = 10f; // Force applied when jumping
    public float climbSpeed = 3f; // Speed for climbing ladders
    private bool isGrounded; // To check if the player is on the ground
    private bool isOnLadder; // To check if the player is on a ladder
    private bool isCrouching; // To track if the player is crouching
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private GameManager gameManager;

    // Collider size and offset for crouching
    private Vector2 normalColliderSize;
    private Vector2 normalColliderOffset;
    public Vector2 crouchingColliderSize = new Vector2(1f, 0.5f);
    public Vector2 crouchingColliderOffset = new Vector2(0f, -0.25f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = FindObjectOfType<GameManager>();

        // Store the original size and offset of the collider
        normalColliderSize = boxCollider.size;
        normalColliderOffset = boxCollider.offset;
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        // Handle crouching
        if (Input.GetKey(KeyCode.S) && isGrounded) // Crouch only when grounded
        {
            Crouch();
        }
        else if (!Input.GetKey(KeyCode.S))
        {
            StandUp();
        }

        // Ladder climbing and movement
        if (isOnLadder)
        {
            float verticalInput = 0f;

            // Climbing with Q and E
            if (Input.GetKey(KeyCode.Q))
            {
                verticalInput = 1f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                verticalInput = -1f;
            }

            // Allow vertical climbing
            rb.velocity = new Vector2(moveInput * moveSpeed, verticalInput * climbSpeed);
            rb.gravityScale = 0; // Disable gravity while on the ladder
        }
        else
        {
            // Normal horizontal movement when not on the ladder
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            rb.gravityScale = 1; // Restore gravity
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isOnLadder)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            boxCollider.size = crouchingColliderSize;
            boxCollider.offset = crouchingColliderOffset;
            isCrouching = true;
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            boxCollider.size = normalColliderSize;
            boxCollider.offset = normalColliderOffset;
            isCrouching = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect ladder interaction
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Exit ladder interaction
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Player destroyed. Attempting to call GameManager.PlayerDestroyed.");
        if (gameManager != null)
        {
            gameManager.PlayerDestroyed();
        }
        else
        {
            Debug.LogWarning("GameManager is null during player destruction.");
        }
    }

}