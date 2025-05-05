
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
            leftGoalText.text = leftScore.ToString();
        if (rightGoalText != null)
            rightGoalText.text = rightScore.ToString();
    }

    public int GetLeftScore() => leftScore;
    public int GetRightScore() => rightScore;
}
