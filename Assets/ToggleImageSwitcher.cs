using UnityEngine;
using UnityEngine.UI;

public class ToggleImageSwitcher : MonoBehaviour
{
    public Toggle toggle;
    public Image targetImage;
    public Sprite imageOn;
    public Sprite imageOff;

    public bool isMusicToggle = true;

    void Start()
    {
        if (toggle != null)
        {
            bool isOn = PlayerPrefs.GetInt(isMusicToggle ? "MusicOn" : "SFXOn", 1) == 1;
            toggle.isOn = isOn;
            UpdateState(isOn);

            toggle.onValueChanged.AddListener(UpdateState);
        }
    }

    void UpdateState(bool isOn)
    {
        if (targetImage != null)
        {
            targetImage.sprite = isOn ? imageOn : imageOff;
        }

        if (AudioManager.Instance != null)
        {
            if (isMusicToggle)
                AudioManager.Instance.ToggleMusic(isOn);
            else
                AudioManager.Instance.ToggleSFX(isOn);
        }
    }
}
