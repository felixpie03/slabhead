using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    public TeamUIColorManager teamUIColorManager; // Assign this in Inspector

    private Vector3 spawnPointPlayer1 = new Vector3(-2, -1.5f, 0);
    private Vector3 spawnPointPlayer2 = new Vector3(2, -1.5f, 0);

    void Start()
    {
        SpawnCharacters();
    }

    void SpawnCharacters()
    {
        int player1CharacterIndex = PlayerPrefs.GetInt("Player1Character", 0);
        int player2CharacterIndex = PlayerPrefs.GetInt("Player2Character", 0);

        GameObject player1 = Instantiate(characterPrefabs[player1CharacterIndex], spawnPointPlayer1, Quaternion.identity);
        GameObject player2 = Instantiate(characterPrefabs[player2CharacterIndex], spawnPointPlayer2, Quaternion.identity);

        // Enable correct controller
        if (player1.TryGetComponent<PlayerController>(out var pc1)) pc1.enabled = false;
        if (player1.TryGetComponent<PlayerControllerWASD>(out var wasd1)) wasd1.enabled = true;

        if (player2.TryGetComponent<PlayerControllerWASD>(out var wasd2)) wasd2.enabled = false;
        if (player2.TryGetComponent<PlayerController>(out var pc2)) pc2.enabled = true;

        // Assign UI colors if available
        if (teamUIColorManager != null)
        {
            PlayerIdentity id1 = player1.GetComponent<PlayerIdentity>();
            PlayerIdentity id2 = player2.GetComponent<PlayerIdentity>();

            if (id1 != null && id2 != null)
            {
                teamUIColorManager.SetPlayerColors(id1.playerColor, id2.playerColor);
            }
        }
    }
}
