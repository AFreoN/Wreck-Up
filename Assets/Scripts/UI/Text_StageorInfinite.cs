using UnityEngine;
using UnityEngine.UI;

public class Text_StageorInfinite : MonoBehaviour
{
    Text tex;
    Animator anim;

    bool changed;

    void Start()
    {
        tex = GetComponent<Text>();
        anim = GetComponent<Animator>();

        changed = GameManager.instance.isInfinite;
        if(changed)
        {
            tex.text = "HighScore  " + PlayerPrefs.GetInt("highscore");
        }
        else
        {
            tex.text = "Level  " + PlayerPrefs.GetInt("Level");
        }
    }
    void Update()
    {
        if(GameManager.instance.isInfinite != changed)
        {
            anim.SetTrigger("play");
            changed = GameManager.instance.isInfinite;
            if (changed)
            {
                tex.text = "HighScore  " + PlayerPrefs.GetInt("highscore");
            }
            else
            {
                tex.text = "Level  " + PlayerPrefs.GetInt("Level");
            }
        }
    }
}
