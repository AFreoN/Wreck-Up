using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Transform ShootingBall;
    public Transform ShootingPoint;

    public GameObject guideLine;

    public float BallSpeed = 10;
    public float RotationSpeed = 1;
    [Range(0,1)]
    public float LerpSpeed = .5f;
    [Range(0, 1)]
    public float ReturnLerpSpeed = .15f;

    bool haveInput = false;

    float StartPos, CurPos;

    void Start()
    {
        guideLine.SetActive(false);
    }
    void Update()
    {
        if (GameManager.dead == false && GameManager.StartGame == true)
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                getAndroidInput();
            }
            else if (Application.platform != RuntimePlatform.Android)
            {
                GetInput();
            }

            if (haveInput == false)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, ReturnLerpSpeed);
            }
        }
    }

    void GetInput()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                haveInput = true;
                StartPos = Input.mousePosition.x;

                guideLine.SetActive(true);
            }

            else if (Input.GetMouseButton(0) && haveInput == true)
            {
                CurPos = Input.mousePosition.x;

                float r = (StartPos - CurPos) * RotationSpeed / Screen.width;

                Quaternion final = Quaternion.Euler(0, 0, -r);

                transform.rotation = Quaternion.Slerp(transform.rotation, final, LerpSpeed);
            }

            else if (Input.GetMouseButtonUp(0) && haveInput == true)
            {
                haveInput = false;
                guideLine.SetActive(false);

                if (NoofBalls.ballsPlayerHave > 0)
                {
                    Transform ball = Instantiate(ShootingBall, ShootingPoint.position, transform.rotation);
                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

                    rb.AddForce(transform.up * BallSpeed, ForceMode2D.Impulse);

                    Destroy(ball.gameObject, 3);

                    NoofBalls.ballsPlayerHave -= 1;
                }
            }
        }
    }

    void getAndroidInput()
    {
        if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                haveInput = true;
                StartPos = touch.position.x;

                guideLine.SetActive(true);
            }

            else if (haveInput == true && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                CurPos = touch.position.x;

                float r = (StartPos - CurPos) * RotationSpeed / Screen.width;

                Quaternion final = Quaternion.Euler(0, 0, -r);

                transform.rotation = Quaternion.Slerp(transform.rotation, final, LerpSpeed);
            }

            else if (haveInput == true && touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                haveInput = false;
                guideLine.SetActive(false);

                if (NoofBalls.ballsPlayerHave > 0)
                {
                    Transform ball = Instantiate(ShootingBall, ShootingPoint.position, transform.rotation);
                    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

                    rb.AddForce(transform.up * BallSpeed, ForceMode2D.Impulse);

                    Destroy(ball.gameObject, 3);

                    NoofBalls.ballsPlayerHave -= 1;
                }
            }
        }
    }
}
