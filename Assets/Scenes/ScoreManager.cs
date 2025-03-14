using UnityEngine;
using TMPro;  // Add this to use TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI instead of Text for TextMeshPro
    public int score = 0;  // Starting score

    void Start()
    {
        // Ensure the scoreText is assigned properly
        if (scoreText == null)
        {
            Debug.LogError("ScoreText is not assigned in the ScoreManager!");
            return;
        }

        UpdateScoreText();  // Update the score display at the start
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();  // Update the score on the screen
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
