using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurNextStageNo : MonoBehaviour
{
    public Text CurLvltext;
    public Text NextLvltext;

    public GameObject tuts1,tuts2;

    void Start()
    {
        CurLvltext.text = PlayerPrefs.GetInt("Level").ToString();
        NextLvltext.text = (PlayerPrefs.GetInt("Level")+1).ToString();

        if(PlayerPrefs.GetInt("Level") != 1)
        {
            tuts1.SetActive(false);
            tuts2.SetActive(false);
        }
        else
        {
            tuts1.SetActive(true);
            tuts2.SetActive(true);
            StartCoroutine(close());
        }
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(3);
        tuts1.SetActive(false);
        tuts2.SetActive(false);
    }
}
