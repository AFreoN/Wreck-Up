using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power = 0.1f;
    public float duration = 1;
    public static bool shouldShake = false;

    Vector3 startPosition;
    Vector3 shakePositon;
    float initDuration;
    void Start ()
    {
        startPosition = transform.position;
        initDuration = duration;
	}
	
	void Update ()
    {
		if(shouldShake == true)
        {
            if(duration > 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * power;
                shakePositon = transform.position;
                duration -= Time.deltaTime;
            }
            else
            {
                shouldShake = false;
                duration = initDuration;
                transform.position = new Vector3(shakePositon.x,startPosition.y,shakePositon.z);
            }
        }
	}
}
