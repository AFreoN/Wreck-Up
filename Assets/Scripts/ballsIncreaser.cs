using UnityEngine;

public class ballsIncreaser : MonoBehaviour
{
    public int ballstoIncreaseMin = 2;
    public int ballstoIncreaseMax = 6;

    SpriteRenderer thisSprite;

    [HideInInspector]
    public int balltoIncrease;

    TextMesh noofballs;

    private void Awake()
    {

    }

    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        thisSprite.color = GameManager.ShootingBallColor;

        balltoIncrease = Random.Range(ballstoIncreaseMin, ballstoIncreaseMax + 1);
        noofballs = transform.GetChild(0).GetComponent<TextMesh>();
        noofballs.text = balltoIncrease.ToString();
    }

    private void Update()
    {
        if(thisSprite.color != GameManager.ShootingBallColor)
        {
            thisSprite.color = GameManager.ShootingBallColor;
        }
    }
}
