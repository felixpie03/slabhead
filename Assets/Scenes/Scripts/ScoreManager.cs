using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftGoalText;
    public TextMeshProUGUI rightGoalText;

    private int leftScore = 0;
    private int rightScore = 0;

    public float scoreCooldown = 0.5f; // Cooldown duration in seconds
    private float lastScoreTime = -999f; // Tracks time of last score

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseLeftScore(int amount)
    {
        if (Time.time - lastScoreTime < scoreCooldown) return;

        leftScore += amount;
        lastScoreTime = Time.time;
        UpdateScoreText();
    }

    public void IncreaseRightScore(int amount)
    {
        if (Time.time - lastScoreTime < scoreCooldown) return;

        rightScore += amount;
        lastScoreTime = Time.time;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (leftGoalText != null)
            leftGoalText.text = leftScore.ToString();
        if (rightGoalText != null)
            rightGoalText.text = rightScore.ToString();
    }

    public int GetLeftScore() => leftScore;
    public int GetRightScore() => rightScore;
}
