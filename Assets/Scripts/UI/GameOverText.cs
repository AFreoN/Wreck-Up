using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public string[] startText;
    public string[] middleText;
    public string[] endText;

    public Image FillerImg;

    Text gameOverText;
    int t;

    void OnEnable()
    {
        gameOverText = GetComponent<Text>();

        if (PlayerPrefs.GetInt("type") == 0)
        {
            if (FillerImg.fillAmount <= .25f)
            {
                t = 1;
            }
            else if (FillerImg.fillAmount <= .75f)
            {
                t = 2;
            }
            else
            {
                t = 3;
            }

            GetString(t);
        }
        else
        {
            if(Score.score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score.score);
                gameOverText.text = "New HighScore " + Score.score;
            }
            else
            {
                gameOverText.text = "Game Over";
            }
        }
    }

    void GetString(int c)
    {
        int r;
        switch(c)
        {
            case 1:
                r = Random.Range(0, startText.Length);
                gameOverText.text = startText[r];
                break;

            case 2:
                r = Random.Range(0, middleText.Length);
                gameOverText.text = middleText[r];
                break;

            case 3:
                r = Random.Range(0, endText.Length);
                gameOverText.text = endText[r];
                break;
        }
    }
}
