using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (winnerText == null)
        {
            Debug.LogError("winnerText is not assigned!");
            return;
        }
        if (countdown == null)
        {
            Debug.LogError("countdown is not assigned!");
            return;
        }
        if (scoreManager == null)
        {
            Debug.LogError("scoreManager is not assigned!");
            return;
        }

        if (countdown.GetTimerOn())
        {
            if (countdown.GetTimeLeft() > 0)
            {
                // timer running
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
        StartCoroutine(ReturnToMainMenuAfterDelay(10f));
    }

    private IEnumerator ReturnToMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu"); // Or use SceneManager.LoadScene(0) if it's the first scene
    }

}