using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Image starSparkImage;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void AddStarSparkToUI()
    {
        starSparkImage.gameObject.SetActive(true);
    }
}

