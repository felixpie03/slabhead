using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StadiumSelectionScript : MonoBehaviour
{
    public Sprite[] stadiumSprites; // Array of stadium sprites
    public Image previewStadium; // Image UI element to show the selected stadium preview

    private int currentIndex = 0; // Track the current stadium selection

    void Start()
    {
        UpdatePreview(); // Initialize the preview on start
    }

    public void NextStadium()
    {
        currentIndex = (currentIndex + 1) % stadiumSprites.Length; // Cycle through the stadiums
        UpdatePreview(); // Update the preview image
    }

    public void PreviousStadium()
    {
        currentIndex = (currentIndex - 1 + stadiumSprites.Length) % stadiumSprites.Length; // Cycle backward through the stadiums
        UpdatePreview(); // Update the preview image
    }

    void UpdatePreview()
    {
        previewStadium.sprite = stadiumSprites[currentIndex]; // Set the current stadium sprite to the preview image
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedStadium", currentIndex); // Store the selected stadium index
        SceneManager.LoadScene("CharacterSelection"); // Load the actual game scene, replace "GameScene" with your actual game scene name
    }
}
