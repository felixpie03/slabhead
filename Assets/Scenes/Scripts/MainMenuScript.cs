using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("StadiumSelection");
    }
}
