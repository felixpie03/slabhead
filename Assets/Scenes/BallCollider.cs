using UnityEngine;

public class BallController : MonoBehaviour
{
    public float kickForce = 10f; // How hard the ball is kicked
    private ScoreManager scoreManager;  // Reference to the ScoreManager script
    private bool isScoring = false;  // Flag to check if score has already increased
    public AudioClip goalSound;  // Reference to the sound clip to play on scoring
    private AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Debug log to check if scoreManager is found
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found! Make sure it's in the scene.");
        }

        // If you don't have an AudioSource, log an error
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on the ball! Add an AudioSource component to the ball.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if a Player touched the ball
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D ballRb = GetComponent<Rigidbody2D>();

            if (ballRb != null)
            {
                // Calculate direction to push the ball
                Vector2 kickDirection = (transform.position - collision.transform.position).normalized;

                // Apply force to the ball
                ballRb.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
            }
        }

        // Check if the ball collides with an object tagged "Goal"
        if (collision.gameObject.CompareTag("Goal") && !isScoring)
        {
            // Prevent double-scoring
            isScoring = true;

            // Increase score by 1 when the ball hits the goal
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(1);
            }
            else
            {
                Debug.LogError("ScoreManager is not assigned or not found!");
            }

            // Play the goal sound
            if (audioSource != null && goalSound != null)
            {
                audioSource.PlayOneShot(goalSound);  // Play sound once
            }

            // Reset ball to its original position
            ResetBallPosition();
        }
    }

    // Reset the ball's position
    void ResetBallPosition()
    {
        transform.position = new Vector3(0f, 0f, 0f);  // Set to your desired starting position

        // Stop any movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;  // Stop the ball
        }

        // Reset the scoring flag after a short delay (e.g., 0.5 seconds)
        Invoke("ResetScoringFlag", 0.5f);
    }

    // Reset the scoring flag to allow scoring again
    void ResetScoringFlag()
    {
        isScoring = false;
    }
}
