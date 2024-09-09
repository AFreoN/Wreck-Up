using UnityEngine;

public class NoofBalls : MonoBehaviour
{
    public static NoofBalls Instance;

    public int balls = 15;
    public static int ballsPlayerHave;

    public static bool isPerfect = true;

    int curBalls;

    public TextMesh ballsText;

    private void Awake()
    {
        Instance = this;
        ballsPlayerHave = balls;
        isPerfect = true;
    }

    void Start()
    {
        ballsText.text = ballsPlayerHave.ToString();

        curBalls = ballsPlayerHave;
    }
    void Update()
    {
        if(ballsPlayerHave != curBalls)
        {
            curBalls = ballsPlayerHave;
            ballsText.text = ballsPlayerHave.ToString();
        }
    }
}
