using System.Collections;
using UnityEngine;

public class PlayerControllerWASD : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private float normalSpeed;
    private float normalJump;
    private Coroutine boostCoroutine;

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    private float lastDirection = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        normalSpeed = moveSpeed;
        normalJump = jumpForce;
    }

    void Update()
    {
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.A)) moveDirection = -1f;
        if (Input.GetKey(KeyCode.D)) moveDirection = 1f;

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        if (moveDirection != 0)
        {
            lastDirection = moveDirection;
        }

        spriteRenderer.flipX = lastDirection < 0;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
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

    public void ActivateSpeedBoost(float duration)
    {
        if (boostCoroutine != null)
            StopCoroutine(boostCoroutine);

        boostCoroutine = StartCoroutine(SpeedBoost(duration));
    }

    private IEnumerator SpeedBoost(float duration)
    {
        moveSpeed = normalSpeed * 1.5f;
        jumpForce = normalJump * 1.2f;

        yield return new WaitForSeconds(duration);

        moveSpeed = normalSpeed;
        jumpForce = normalJump;
        boostCoroutine = null;
    }
}
