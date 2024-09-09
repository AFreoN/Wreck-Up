using UnityEngine;

public class HVmovement : MonoBehaviour
{
    public MovementType Movement = MovementType.Horizontal;
    public RotationType Rotation = RotationType.Clockwise;
    public bool isMovable = true;
    public bool isRotatable = false;

    public float MovementSpeed = 300f;
    public float MaxDistance = 4.2f;
    public float RotationSpeed = 25f;

    Rigidbody2D rb;

    float StartYpos;

    public bool isRandomized = true;
    public bool right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(isRandomized)
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
        StartYpos = transform.position.y;
    }

    private void Update()
    {
        if (isMovable)
        {
            StartMove();
        }
        if(isRotatable)
        {
            startRotation();
        }
    }

    void StartMove()
    {
        switch(Movement)
        {
            case MovementType.Horizontal:
                if (right == false)
                {
                    if (transform.position.x > -MaxDistance)
                    {
                        rb.velocity = Vector2.left * MovementSpeed * Time.deltaTime;
                    }
                    else
                    {
                        right = true;
                    }
                }
                else
                {
                    if (transform.position.x < MaxDistance)
                    {
                        rb.velocity = Vector2.right * MovementSpeed * Time.deltaTime;
                    }
                    else
                    {
                        right = false;
                    }
                }
                break;
            case MovementType.Vertical:
                if (right == false)
                {
                    if (transform.position.y > StartYpos-MaxDistance)
                    {
                        rb.velocity = Vector2.down * MovementSpeed * Time.deltaTime;
                    }
                    else
                    {
                        right = true;
                    }
                }
                else
                {
                    if (transform.position.y < MaxDistance + StartYpos)
                    {
                        rb.velocity = Vector2.up * MovementSpeed * Time.deltaTime;
                    }
                    else
                    {
                        right = false;
                    }
                }
                break;
        }
    }

    void startRotation()
    {
        switch(Rotation)
        {
            case RotationType.Clockwise:
                rb.AddTorque(RotationSpeed * Time.fixedDeltaTime);
                break;
            case RotationType.AntiClockwise:
                rb.AddTorque(-RotationSpeed * Time.fixedDeltaTime);
                break;
        }
    }

    public enum MovementType
    {
        Horizontal,
        Vertical
    }

    public enum RotationType
    {
        Clockwise,
        AntiClockwise
    }
}
