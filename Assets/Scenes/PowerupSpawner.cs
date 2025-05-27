using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public float spawnInterval = 20f;

    public Vector2 spawnAreaMin = new Vector2(-5f, 1f);
    public Vector2 spawnAreaMax = new Vector2(5f, 3f);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerup), spawnInterval, spawnInterval);
    }

    private void SpawnPowerup()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        Debug.Log("Spawne Powerup bei: " + spawnPos);
        Instantiate(powerupPrefab, spawnPos, Quaternion.identity);
    }
}
