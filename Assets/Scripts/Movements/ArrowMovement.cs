using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float MovementSpeed = 400f;

    public float rotSpeed = 150f;

    public float MaxDistance = 4.2f;

    Rigidbody2D rb;
    bool right = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(right)
        {
            if (transform.position.x < MaxDistance)
            {
                rb.velocity = Vector2.right * MovementSpeed * Time.deltaTime;
            }
            else if(transform.rotation.eulerAngles.z < 180)
            {
                rb.velocity = Vector2.zero;
                transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else
            {
                right = false;
            }
        }

        else
        {
            if(transform.position.x > -MaxDistance)
            {
                rb.velocity = Vector2.left * MovementSpeed * Time.deltaTime;
            }
            else if(transform.rotation.eulerAngles.z >= 180)
            {
                rb.velocity = Vector2.zero;
                transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            }
            else
            {
                right = true;
            }
        }
    }
}
