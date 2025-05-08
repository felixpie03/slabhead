using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Sprite[] characterSprites;

    public Image previewPlayer1;
    public Image previewPlayer2;

    private int indexPlayer1 = 0;
    private int indexPlayer2 = 0;

    void Start()
    {
        UpdatePreview();
    }

    public void NextCharacterPlayer1()
    {
        indexPlayer1 = (indexPlayer1 + 1) % characterSprites.Length;
        UpdatePreview();
    }

    public void PreviousCharacterPlayer1()
    {
        indexPlayer1 = (indexPlayer1 - 1 + characterSprites.Length) % characterSprites.Length;
        UpdatePreview();
    }

    public void NextCharacterPlayer2()
    {
        indexPlayer2 = (indexPlayer2 + 1) % characterSprites.Length;
        UpdatePreview();
    }

    public void PreviousCharacterPlayer2()
    {
        indexPlayer2 = (indexPlayer2 - 1 + characterSprites.Length) % characterSprites.Length;
        UpdatePreview();
    }

    void UpdatePreview()
    {
        previewPlayer1.sprite = characterSprites[indexPlayer1];
        previewPlayer2.sprite = characterSprites[indexPlayer2];
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("Player1Character", indexPlayer1);
        PlayerPrefs.SetInt("Player2Character", indexPlayer2);
        SceneManager.LoadScene("Bernabeu");
    }
}

