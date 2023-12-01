using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    // Reference to the AudioSource component
    private AudioSource musicSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource component from this GameObject
            musicSource = GetComponent<AudioSource>();
            if (musicSource == null)
            {
                Debug.LogWarning("MusicManager: AudioSource component missing.");
            }
            else
            {
                // Optionally, initialize volume from PlayerPrefs
                musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to change the volume
    public void SetVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;

            // Optionally, save the volume to PlayerPrefs
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }
    }
}
