using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

private void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadSettings();

    if (!musicSource.isPlaying && musicSource.clip != null && !musicSource.mute)
    {
        musicSource.Play();
    }
}


    public void ToggleMusic(bool on)
    {
        musicSource.mute = !on;
        PlayerPrefs.SetInt("MusicOn", on ? 1 : 0);
    }

    public void ToggleSFX(bool on)
    {
        sfxSource.mute = !on;
        PlayerPrefs.SetInt("SFXOn", on ? 1 : 0);
    }

    void LoadSettings()
    {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        bool sfxOn = PlayerPrefs.GetInt("SFXOn", 1) == 1;

        musicSource.mute = !musicOn;
        sfxSource.mute = !sfxOn;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (!sfxSource.mute && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
