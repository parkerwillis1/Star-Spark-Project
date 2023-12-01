using UnityEngine;

public class StarSpark : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the Star Spark
        if (other.CompareTag("Player"))
        {
            PlayPickupSound();  // Play the pickup sound
            UIManager.Instance.AddStarSparkToUI(); // Add Star Spark to UI
            Destroy(gameObject); // Destroy the Star Spark object
        }
    }

    private void PlayPickupSound()
    {
        // Play the sound at the position of the Star Spark
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
    }
}


