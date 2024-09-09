using UnityEngine;

public class ZRotation : MonoBehaviour
{
    public rotation RotationSide = rotation.Clockwise;
    public float rotationSpeed = 400f;

    void Start()
    {
        
    }
    void Update()
    {
        if (RotationSide == rotation.Clockwise)
        {
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    public enum rotation
    {
        Clockwise,
        Anticlockwise
    }
}
