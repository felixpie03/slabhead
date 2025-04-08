using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
 

    private float TimeLeft = 30f;
    private bool TimerOn = true;

    public ScoreManager scoreManager;


    void Start()
    {
        TimerOn = true;
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
        if (scoreManager.GetRightScore() == scoreManager.GetLeftScore())
        {
            return true;
        }
        return false;
    }
   
    public float GetTimeLeft()
    {
        return TimeLeft;
    }
    public bool GetTimerOn()
    {
        return TimerOn;
    }


}
