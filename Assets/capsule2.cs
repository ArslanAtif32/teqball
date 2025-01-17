using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float rotationSpeed = 360f; // Speed of rotation (degrees per second)
    private bool isRotating = false; // Flag to check if the player is rotating
    private float rotationAngle = 0f; // Angle rotated so far

    private void Update()
    {
        // Handle player movement (Arrow keys)
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveHorizontal = -1f; // Move left along the X-axis
        if (Input.GetKey(KeyCode.RightArrow))
            moveHorizontal = 1f;  // Move right along the X-axis
        if (Input.GetKey(KeyCode.UpArrow))
            moveVertical = 1f;    // Move up along the Y-axis
        if (Input.GetKey(KeyCode.DownArrow))
            moveVertical = -1f;   // Move down along the Y-axis

        // Apply movement
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Handle rotation (P key)
        if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            isRotating = true; // Start rotating
        }

        if (isRotating)
        {
            RotatePlayer();
        }
    }

    private void RotatePlayer()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        rotationAngle += rotationThisFrame;

        if (rotationAngle >= 360f)
        {
            rotationThisFrame -= (rotationAngle - 360f); // Adjust to complete exactly one full rotation
            isRotating = false; // Stop rotating
            rotationAngle = 0f; // Reset rotation angle
        }

        transform.Rotate(0, 0, rotationThisFrame);
    }
}
