using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float minX = -5f; // Minimum X position
    public float maxX = 5f; // Maximum X position

    private Vector3 touchPosition;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Get the screen width
            float screenWidth = Screen.width;

            // Check if the touch is on the left or right side of the screen
            if (touch.position.x < screenWidth / 2)
            {
                // Left side of the screen: move the paddle left
                touchPosition = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                // Right side of the screen: move the paddle right
                touchPosition = transform.position + Vector3.right * speed * Time.deltaTime;
            }

            // Clamp the paddle's X position within minX and maxX
            touchPosition.x = Mathf.Clamp(touchPosition.x, minX, maxX);

            // Set the new position of the paddle
            transform.position = touchPosition;
        }
    }
}