using UnityEngine;

public class PlayerControllerWASD : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    private float lastDirection = 1f; // 1 = right, -1 = left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A)) moveDirection = -1f;
        if (Input.GetKey(KeyCode.D)) moveDirection = 1f;

        // Apply movement
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        // Update last direction if moving
        if (moveDirection != 0)
        {
            lastDirection = moveDirection;
        }

        // Flip sprite based on last known direction
        spriteRenderer.flipX = lastDirection > 0;

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        checkWworks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void checkWworks()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W was pressed");
        }
    }
}
