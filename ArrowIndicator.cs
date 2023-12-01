using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    public Transform portalTransform;
    public Camera mainCamera;
    private RectTransform arrowRectTransform; // Use RectTransform for UI elements

    void Start()
    {
        arrowRectTransform = GetComponent<RectTransform>();
        gameObject.SetActive(false); // Start with the arrow disabled
    }

    void Update()
    {
        if (gameObject.activeSelf && portalTransform != null)
        {
            PointTowardsPortal();
        }
    }

    public void ActivateArrow()
    {
        gameObject.SetActive(true);
    }

    private void PointTowardsPortal()
    {
        // Convert portal position to a position on the screen
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(portalTransform.position);

        // Check if the portal is off-screen
        bool isOffScreen = screenPoint.x <= 0 || screenPoint.x >= Screen.width ||
                           screenPoint.y <= 0 || screenPoint.y >= Screen.height;

        if (isOffScreen)
        {
            // Determine offset values - adjust these as needed
            float offsetX = 100; // Example horizontal offset
            float offsetY = 100; // Example vertical offset

            // Keep the arrow within the screen bounds
            screenPoint.x = Mathf.Clamp(screenPoint.x, 0, Screen.width);
            screenPoint.y = Mathf.Clamp(screenPoint.y, 0, Screen.height);

            // Set the arrow's position with offset
            arrowRectTransform.anchoredPosition = new Vector2(offsetX, offsetY);

            // Calculate the direction from the arrow to the portal
            Vector2 fromPosition = arrowRectTransform.position;
            Vector2 toPosition = screenPoint;
            Vector2 direction = toPosition - fromPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation to the arrow
            arrowRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        }
        
    }

}


