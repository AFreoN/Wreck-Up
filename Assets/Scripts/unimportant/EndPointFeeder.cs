using UnityEngine;

public class EndPointFeeder : MonoBehaviour
{
    public Transform endPoint;
    public int LevelNo;

    void Start()
    {
        StageDisCalculator.instance.feedObject(endPoint);
    }
}
