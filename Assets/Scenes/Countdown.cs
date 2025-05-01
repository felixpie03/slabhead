using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    private float TimeLeft = 30f;
    private bool TimerOn = true;

    public ScoreManager scoreManager;

    public AudioClip whistleStart;
    public AudioClip whistleEnd;

    void Start()
    {
        TimerOn = true;

        if (AudioManager.Instance != null && whistleStart != null)
        {
            AudioManager.Instance.PlaySFX(whistleStart);
        }
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                if (isDraw())
                {
                    TimeLeft = 60f;
                }
                else
                {
                    Debug.Log("Time is Up");
                    TimeLeft = 0;
                    TimerOn = false;

                    if (AudioManager.Instance != null && whistleEnd != null)
                    {
                        AudioManager.Instance.PlaySFX(whistleEnd);
                    }

                    WinnerManager winnerManager = FindFirstObjectByType<WinnerManager>();
                    if (winnerManager != null)
                    {
                        winnerManager.ShowWinner();
                    }

                    // Time.timeScale = 0f;
                }
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    bool isDraw()
    {
        return scoreManager != null && scoreManager.GetLeftScore() == scoreManager.GetRightScore();
    }

    public bool GetTimerOn()
    {
        return TimerOn;
    }

    public float GetTimeLeft()
    {
        return TimeLeft;
    }
}
