using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftGoalText;
    public TextMeshProUGUI rightGoalText;

    private int leftScore = 0;
    private int rightScore = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseLeftScore(int amount)
    {
        leftScore += amount;
        UpdateScoreText();
    }

    public void IncreaseRightScore(int amount)
    {
        rightScore += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (leftGoalText != null)
            leftGoalText.text = "Player 1: " + leftScore.ToString();
        if (rightGoalText != null)
            rightGoalText.text = "Player 2: " + rightScore.ToString();
    }

    public int GetLeftScore() { return leftScore; }

    public int GetRightScore() { return rightScore; }
}
