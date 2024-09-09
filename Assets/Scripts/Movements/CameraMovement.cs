using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float LerpSpeed = .25f;

    public bool Zoom = false;
    public float EndOrthoGraphicSize = 4.2f;
    public float ZoomSpeed = .35f;
    float camSize;
    float offset;
    float StartZpos;

    public Transform BgReference;
    Camera MainCamera;
    bool SceneFinished = false;

    public static bool ShouldShake = false;
    [Header("For Camera Shake")]
    public float Duration = .2f;
    public float Power = .5f;
    float initDuration;

    void Awake()
    {
        ShouldShake = false;
        initDuration = Duration;
        MainCamera = GetComponent<Camera>();

        float c = (float)Screen.width / (float)Screen.height;

        //For OrthoSize
        if (c < 0.6f)
        {
            camSize = BgReference.GetComponent<SpriteRenderer>().bounds.size.x * Screen.height / Screen.width * 0.5f;
        }
        else
        {
            camSize = BgReference.GetComponent<SpriteRenderer>().bounds.size.y * 0.5f;
        }
        //
        MainCamera.orthographicSize = camSize;

        offset = transform.position.y - target.position.y;
        StartZpos = transform.position.z;
    }
    void FixedUpdate()
    {
        //if (GameManager.dead == false && GameManager.StartGame == true)
        //{
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, offset + target.position.y, StartZpos), LerpSpeed);
        //}

        if(ShouldShake)
        {
            if(Duration > 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * Power;
                Duration -= Time.deltaTime;
            }
            else
            {
                ShouldShake = false;
                Duration = initDuration;
            }
        }


        //if(Zoom == true && MainCamera.orthographicSize > EndOrthoGraphicSize + .2f)
        //{
        //    SceneFinished = true;
        //    float endsize = Mathf.Lerp(MainCamera.orthographicSize, EndOrthoGraphicSize, ZoomSpeed);

        //    MainCamera.orthographicSize = endsize;
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(0, target.position.y, StartZpos), ZoomSpeed);
        //}
        //else if(SceneFinished == true && MainCamera.orthographicSize < camSize - 1)
        //{
        //    Zoom = false;
        //    float ret = Mathf.Lerp(MainCamera.orthographicSize, camSize, ZoomSpeed);

        //    MainCamera.orthographicSize = ret;
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(0, offset + target.position.y, StartZpos), LerpSpeed);
        //}
        //else if(SceneFinished == true)
        //{
        //    SceneFinished = false;
        //    GameManager.instance.LoadMainMenu();
        //}
    }
}
