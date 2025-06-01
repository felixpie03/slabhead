using UnityEngine;

public class StadiumManager : MonoBehaviour
{
    public GameObject[] stadiums; // Array of stadium GameObjects or background sprites

    void Start()
    {
        int selectedStadium = PlayerPrefs.GetInt("SelectedStadium", 0);

        // Disable all stadiums
        for (int i = 0; i < stadiums.Length; i++)
        {
            stadiums[i].SetActive(false);
        }

        // Enable selected stadium
        if (selectedStadium >= 0 && selectedStadium < stadiums.Length)
        {
            stadiums[selectedStadium].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Selected stadium index is out of bounds.");
        }
    }
}
