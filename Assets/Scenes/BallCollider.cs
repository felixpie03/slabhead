using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float kickForce = 10f;
    private ScoreManager scoreManager;
    private bool isScoring = false;
    public AudioClip goalSound;
    private AudioSource audioSource;

    private Vector3 startPosition;
    private Rigidbody2D rb;
    public float resetDelay = 1f;   

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");
        if (audioSource == null)
            Debug.LogError("No AudioSource on Ball!");
        if (rb == null)
            Debug.LogError("No Rigidbody2D on Ball!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isScoring && scoreManager != null)
        {
            if (other.CompareTag("LeftGoal"))
            {
                Debug.Log("Linkes Tor!");
                isScoring = true;
                scoreManager.IncreaseLeftScore(1);
                if (goalSound != null)
                    audioSource.PlayOneShot(goalSound);
                StartCoroutine(ResetBallWithDelay());
            }
            else if (other.CompareTag("RightGoal"))
            {
                Debug.Log("Rechtes Tor!");
                isScoring = true;
                scoreManager.IncreaseRightScore(1);
                if (goalSound != null)
                    audioSource.PlayOneShot(goalSound);
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


IEnumerator ResetBallWithDelay()
{
    yield return new WaitForSeconds(resetDelay);
    rb.linearVelocity = Vector2.zero;
    rb.angularVelocity = 0f;
    transform.position = startPosition;
}

}
