using UnityEngine;

public class AdrenalinePowerup : MonoBehaviour
{
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var p1 = other.GetComponent<PlayerController>();
            var p2 = other.GetComponent<PlayerControllerWASD>();

            if (p1 != null) p1.ActivateSpeedBoost(boostDuration);
            if (p2 != null) p2.ActivateSpeedBoost(boostDuration);

            Destroy(this.gameObject);
        }
    }
}
