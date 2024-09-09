using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageFinishPanel : MonoBehaviour
{
    public GameObject StageFinishedText;
    public GameObject PerfectText;

    private void OnEnable()
    {
        if(NoofBalls.isPerfect)
        {
            PerfectText.SetActive(true);
            StageFinishedText.SetActive(false);
        }
        else
        {
            PerfectText.SetActive(false);
            StageFinishedText.SetActive(true);
            StageFinishedText.GetComponent<Text>().text = "Level " + GameObject.Find("StartEndFeeder").GetComponent<EndPointFeeder>().LevelNo + " completed";
        }
    }
}
