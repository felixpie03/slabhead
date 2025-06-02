using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        normalSpeed = moveSpeed;
        normalJump = jumpForce;
        startPosition = transform.position;
    }

    void Update()
    {
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveDirection = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveDirection = 1f;

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        if (moveDirection != 0)
        {
            lastDirection = moveDirection;
        }

        spriteRenderer.flipX = lastDirection < 0;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
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

    public void ResetPlayer()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            
        }

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = startPosition;
    }
    public void SetStartPosition(Vector3 pos)
    {
        startPosition = pos;
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
