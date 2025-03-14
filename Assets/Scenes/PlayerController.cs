using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator; // ✅ Animator reference

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // ✅ Get the Animator component
    }

    void Update()
    {
        float horizontal1 = Input.GetAxis("Horizontal");

        float horizontal2 = 0f;
        if (Input.GetKey(KeyCode.A)) horizontal2 = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal2 = 1f;

        float moveDirection = horizontal1 + horizontal2;

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        // ✅ Flip character sprite based on movement direction
        if (moveDirection > 0)
        {
            spriteRenderer.flipX = true; 
        }
        else if (moveDirection < 0)
        {
            spriteRenderer.flipX = false;
        }

        // ✅ Set running animation
        animator.SetBool("isRunning", moveDirection != 0);

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
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
