using UnityEngine;

public class PlayerController : MonoBehaviour
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

        if (Input.GetKey(KeyCode.LeftArrow)) moveDirection = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveDirection = 1f;

        // Apply movement
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        // Update last direction if input was made
        if (moveDirection != 0)
        {
            lastDirection = moveDirection;
        }

        // Flip sprite based on last direction
        spriteRenderer.flipX = lastDirection > 0;

        // Jump
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
