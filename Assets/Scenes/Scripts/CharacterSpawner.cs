using UnityEngine;
using UnityEngine.UI;  // For UI Image component

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Image player1BadgeImage;  // UI Image for Player 1's badge
    public Image player2BadgeImage;  // UI Image for Player 2's badge
    public Image player1IdentityColorImage;  // UI Image for Player 1's identity color (e.g., color background)
    public Image player2IdentityColorImage;  // UI Image for Player 2's identity color (e.g., color background)

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

        // Instantiate players
        GameObject player1 = Instantiate(characterPrefabs[player1CharacterIndex], spawnPointPlayer1, Quaternion.identity);
        SetPlayerStartPosition(player1, spawnPointPlayer1);
        GameObject player2 = Instantiate(characterPrefabs[player2CharacterIndex], spawnPointPlayer2, Quaternion.identity);
        SetPlayerStartPosition(player2, spawnPointPlayer2);

        // Set Player 1 controls to WASD
        if (player1.TryGetComponent<PlayerController>(out var pc1)) pc1.enabled = false;
        if (player1.TryGetComponent<PlayerControllerWASD>(out var wasd1)) wasd1.enabled = true;

        // Set Player 2 controls to Arrow keys
        if (player2.TryGetComponent<PlayerControllerWASD>(out var wasd2)) wasd2.enabled = false;
        if (player2.TryGetComponent<PlayerController>(out var pc2)) pc2.enabled = true;

        GameObject ball = GameObject.FindWithTag("Ball");
        if (ball != null && ball.TryGetComponent<BallController>(out var ballController))
        {
            ballController.player1 = player1;
            ballController.player2 = player2;
        }

        // Get Player Identity components and set UI badges and color backgrounds
        PlayerIdentity player1Identity = player1.GetComponent<PlayerIdentity>();
        PlayerIdentity player2Identity = player2.GetComponent<PlayerIdentity>();

        // Assign the badge (this is the static image)
        if (player1Identity != null && player1BadgeImage != null)
        {
            player1BadgeImage.sprite = player1Identity.playerBadge;
        }

        if (player2Identity != null && player2BadgeImage != null)
        {
            player2BadgeImage.sprite = player2Identity.playerBadge;
        }

        // Set the identity color image (e.g., background or color plate)
        if (player1Identity != null && player1IdentityColorImage != null)
        {
            player1IdentityColorImage.color = player1Identity.playerColor;  // Use the player's identity color
        }

        if (player2Identity != null && player2IdentityColorImage != null)
        {
            player2IdentityColorImage.color = player2Identity.playerColor;  // Use the player's identity color
        }
    }

    void SetPlayerStartPosition(GameObject player, Vector3 position)
    {
        var pc = player.GetComponent<PlayerController>();
        if (pc != null) pc.SetStartPosition(position);

        var pcWASD = player.GetComponent<PlayerControllerWASD>();
        if (pcWASD != null) pcWASD.SetStartPosition(position);
    }
}
