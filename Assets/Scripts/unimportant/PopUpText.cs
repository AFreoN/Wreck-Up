using UnityEngine;

public class PopUpText : MonoBehaviour
{
    public float LerpDis = 0.5f;
    [Range(0,1)]
    public float LerpSpeed = 0.4f;
    [Range(0,1)]
    public float ColorLerpSpeed = 0.1f;
    public bool isLerpable = true;
    public float DestoryTime = 1;

    Vector3 Destination;
    Color textColor;

    TextMesh thisText;

    private void Awake()
    {
        thisText = GetComponent<TextMesh>();
        thisText.color = GameManager.ShootingBallColor;
    }

    private void Start()
    {
        Destination = new Vector3(transform.position.x, transform.position.y + LerpDis, transform.position.z);
        textColor = GetComponent<TextMesh>().color;
        Destroy(gameObject, 1);
    }

    void Update()
    {
        if(isLerpable && transform.position != Destination)
        {
            transform.position = Vector3.Lerp(transform.position,Destination, LerpSpeed);

            textColor.a = 0;
            thisText.color = Color.Lerp(thisText.color,textColor,0.1f);
        }
    }
}
