using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static TimeManager Instance;

    public float slowDownTime = 0.5f;
    public float slowedTimeScale = 0.1f;

    float t = 0;
    [HideInInspector]
    public bool SlowDown = false;
    bool getvalues = false;

    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if(SlowDown == true)
        {
            if(getvalues == false)
            {
                GetValues();
                getvalues = true;
            }

            if(t >= Time.unscaledTime)
            {
                if (Time.timeScale != slowedTimeScale)
                {
                    Time.timeScale = slowedTimeScale;
                    Time.fixedDeltaTime = slowedTimeScale * 0.02f;
                }
            }

            else
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
                t = 0;
                SlowDown = false;
                getvalues = false;
            }
        }
    }

    void GetValues()
    {
        t = Time.unscaledTime + slowDownTime;
    }
}
