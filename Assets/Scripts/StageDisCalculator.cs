using UnityEngine;
using UnityEngine.UI;

public class StageDisCalculator : MonoBehaviour
{
    public static StageDisCalculator instance;
    public Transform player;

    Image FillerImg;

    float totalDis = 0;
    float endPoint;
    bool startCount = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        FillerImg = GetComponent<Image>();
        FillerImg.fillAmount = 0;
    }
    void Update()
    {
        if(startCount)
        {
            float curDis = (endPoint - player.position.y) / totalDis;

            FillerImg.fillAmount =  1 - curDis;
        }
    }

    public void feedObject(Transform endpoint)
    {
        totalDis = endpoint.position.y - player.position.y;
        endPoint = endpoint.position.y;
        startCount = true;

        //FillerImg.color = GameManager.ShootingBallColor;
    }
}
