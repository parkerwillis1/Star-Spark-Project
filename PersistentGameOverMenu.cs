using UnityEngine;

public class PersistentGameOverMenu : MonoBehaviour
{
    private static PersistentGameOverMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        gameObject.SetActive(false); 
    }
}
