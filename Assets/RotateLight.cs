using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the light around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}