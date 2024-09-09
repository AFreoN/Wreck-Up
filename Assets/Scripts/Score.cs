using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    int curScore;

    public Text ScoreText;

    private void Awake()
    {
        score = 0;
        curScore = 0;
    }

    void Start()
    {
        ScoreText.text = score.ToString();
    }
    void Update()
    {
        if(score != curScore)
        {
            curScore = score;
            ScoreText.text = score.ToString();
        }
    }
}
