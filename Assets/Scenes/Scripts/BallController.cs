
using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float kickForce = 10f;
    private ScoreManager scoreManager;
    private bool isScoring = false;

    public AudioClip goalSound;
    public AudioClip goalCheer;
    public AudioClip antonySound;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private GameObject lastTouchPlayer;

    public float resetDelay = 1f;
    public float maxSpeed = 10f;  // Maximum speed for the ball

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>(); // neue empfohlene Methode
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");
        if (rb == null)
            Debug.LogError("No Rigidbody2D on Ball!");
    }

    void FixedUpdate()
    {
        // Clamp the velocity to the max speed
        if (rb != null)
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isScoring && scoreManager != null)
        {
            if (other.CompareTag("LeftGoal"))
            {
                isScoring = true;
                scoreManager.IncreaseLeftScore(1);
                PlayScorerSound();
                StartCoroutine(ResetBallWithDelay());
            }
            else if (other.CompareTag("RightGoal"))
            {
                isScoring = true;
                scoreManager.IncreaseRightScore(1);
                PlayScorerSound();
                StartCoroutine(ResetBallWithDelay());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LeftGoal") || other.CompareTag("RightGoal"))
        {
            isScoring = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lastTouchPlayer = collision.gameObject;
        }
    }

    void PlayScorerSound()
{
    if (lastTouchPlayer != null && lastTouchPlayer.name.Contains("Antony"))
    {
        if (antonySound != null)
            AudioManager.Instance.PlaySFX(antonySound);
    }
    else
    {
        if (goalCheer != null)
            AudioManager.Instance.PlaySFX(goalCheer);
    }

    if (goalSound != null)
        AudioManager.Instance.PlaySFX(goalSound);
}


    IEnumerator ResetBallWithDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = startPosition;
    }
}
