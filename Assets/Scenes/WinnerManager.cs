using System.Collections;
using TMPro;
using UnityEngine;

public class WinnerManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    public Countdown countdown;
    public ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //winnerText.gameObject.SetActive(false);
        winnerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.GetTimerOn())
        {
            if (countdown.GetTimeLeft() > 0)
            {
            }
            else
            {
                if (isDraw())
            {
                    Debug.Log("Draw");
                    ShowDraw();
            }
            else
            {
                Debug.Log("Time is Up");
                ShowWinner();
            }


            }


        }
    }
    bool isDraw()
    {
        if (scoreManager.GetRightScore() == scoreManager.GetLeftScore())
        {
            return true;
        }
        return false;
    }
    public void ShowDraw()
    {
        
        StartCoroutine(ShowDrawCoroutine());
    }

    IEnumerator ShowDrawCoroutine()
    {
        
        //winnerText.gameObject.SetActive(true);
        winnerText.text = "Overtime!";
        yield return new WaitForSeconds(3f);
        winnerText.text = "";
        //winnerText.gameObject.SetActive(false);

    }
    private int SetWinner(ScoreManager scoreManager)
    {
        if (scoreManager == null)
        {
            return 0;
        }
        if (scoreManager.GetRightScore() > scoreManager.GetLeftScore())
        {
            return 2;
        }
        return 1;
    }

    public void ShowWinner()
    {
        //winnerText.gameObject.SetActive(true);
        winnerText.text = $"Player {SetWinner(scoreManager)} won!";
    }

}
