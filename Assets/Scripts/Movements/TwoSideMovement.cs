using UnityEngine;

public class TwoSideMovement : MonoBehaviour
{
    public MovementSide Side = MovementSide.right;
    public float MovementSpeed = 200f;
    public float rotationSpeed = 50f;
    public float MaxDis = 4.5f;

    public bool Right = true;
    public bool isRotatable = false;

    bool onceRotated = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(isRotatable == false)
        {
            withoutRotation();
        }
        else
        {
            withRotation();
        }
    }

    void withRotation()
    {
        if(Right)
        {
            if(transform.position.x >= 0)
            {
                if (transform.localRotation.eulerAngles.z <= 180 && onceRotated == false)
                {
                    rb.velocity = Vector2.zero;
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
                }
                else if(transform.rotation.eulerAngles.z >= 180 && onceRotated)
                {
                    rb.velocity = Vector2.zero;
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
                }
                else if(transform.localPosition.x < MaxDis)
                {
                    rb.velocity = Vector2.right * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = false;
                    onceRotated = !onceRotated;
                }
            }
            else
            {
                rb.velocity = Vector2.right * MovementSpeed * Time.fixedDeltaTime;
            }
        }
        if(Right == false)
        {
            if(transform.position.x <= 0)
            {
                if(transform.localRotation.eulerAngles.z <= 180 && onceRotated == false)
                {
                    rb.velocity = Vector2.zero;
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
                }
                else if(transform.localRotation.eulerAngles.z >= 180 && onceRotated)
                {
                    rb.velocity = Vector2.zero;
                    transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
                }
                else if(transform.localPosition.x > -MaxDis)
                {
                    rb.velocity = Vector2.left * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = true;
                    onceRotated = !onceRotated; 
                }
            }
            else
            {
                rb.velocity = Vector2.left * MovementSpeed * Time.fixedDeltaTime;
            }
        }
    }

    void withoutRotation()
    {
        if (Side == MovementSide.right)
        {
            if (Right)
            {
                if (transform.position.x < MaxDis)
                {
                    rb.velocity = Vector2.right * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = false;
                }
            }
            else
            {
                if (transform.position.x > 0)
                {
                    rb.velocity = Vector2.left * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = true;
                }
            }
        }
        else if (Side == MovementSide.left)
        {
            if (Right == false)
            {
                if (transform.position.x > -MaxDis)
                {
                    rb.velocity = Vector2.left * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = true;
                }
            }
            else
            {
                if (transform.position.x < 0)
                {
                    rb.velocity = Vector2.right * MovementSpeed * Time.fixedDeltaTime;
                }
                else
                {
                    Right = false;
                }
            }
        }
    }

    public enum MovementSide
    {
        right,
        left
    }
}
