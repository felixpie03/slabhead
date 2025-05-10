using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

        public void PlayGame()
    {
        SceneManager.LoadScene("Bernabeu");
    }

void Start()
{
    bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
    bool sfxOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;

    if (musicToggle != null)
    {
        musicToggle.isOn = musicOn;
        ToggleMusic(musicOn);
    }

    if (sfxToggle != null)
    {
        sfxToggle.isOn = sfxOn;
        ToggleSFX(sfxOn);
    }
}

    public void ToggleMusic(bool isOn)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.ToggleMusic(isOn);
    }

    public void ToggleSFX(bool isOn)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.ToggleSFX(isOn);
    }
}