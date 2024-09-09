using UnityEngine;

public class PlayerHinger : MonoBehaviour
{
    public Transform Player;
    public Transform Hinges;

    Transform[] ids;

    int balls;
    Color ballColor;

    void Start()
    {
        balls = NoofBalls.ballsPlayerHave;
        ballColor = GameManager.ShootingBallColor;
        ids = new Transform[balls];
        for(int i=0; i < balls; i++)
        {
            ids[i] = Instantiate(Hinges, new Vector3(Player.position.x, Player.position.y - (i+1), Player.position.z), Quaternion.identity);
            ids[i].GetComponent<SpriteRenderer>().color = ballColor;
            if (i == 0)
            {
                ids[i].GetComponent<HingeJoint2D>().connectedBody = Player.GetComponent<Rigidbody2D>();
            }
            else
            {
                ids[i].GetComponent<HingeJoint2D>().connectedBody = ids[i - 1].GetComponent<Rigidbody2D>();
            }
        }
    }
    void Update()
    {
        if(NoofBalls.ballsPlayerHave != balls)
        {
            balls = NoofBalls.ballsPlayerHave;

            for(int j = 0; j < ids.Length; j++)
            {
                Destroy(ids[j].gameObject);
            }
            ids = new Transform[balls];
            for (int i = 0; i < balls; i++)
            {
                ids[i] = Instantiate(Hinges, new Vector3(Player.position.x, Player.position.y - (i+1), Player.position.z), Quaternion.identity);
                ids[i].GetComponent<SpriteRenderer>().color = ballColor;
                if (i == 0)
                {
                    ids[i].GetComponent<HingeJoint2D>().connectedBody = Player.GetComponent<Rigidbody2D>();
                }
                else
                {
                    ids[i].GetComponent<HingeJoint2D>().connectedBody = ids[i - 1].GetComponent<Rigidbody2D>();
                }
            }
        }

        if(GameManager.ShootingBallColor != ballColor)
        {
            ballColor = GameManager.ShootingBallColor;

            for(int i=0; i < ids.Length; i++)
            {
                ids[i].GetComponent<SpriteRenderer>().color = ballColor;
            }
        }
    }
}
