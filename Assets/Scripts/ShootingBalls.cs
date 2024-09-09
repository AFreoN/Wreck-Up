using UnityEngine;

public class ShootingBalls : MonoBehaviour
{
    public Transform blockHit_PS;
    public Transform bouncerHit_PS;

    public GameObject popUpText;

    public GameObject Paint;
    public float PaintScale = 1.5f;

    public float explosionForceMin = 5f, explosionForceMax = 10f, upwardForceMin = .1f, upwardForceMax = 1f;
    public bool SlowDown = false;

    bool Collided = false;
    bool added = false;
    int bouncy = 0;
    

    void Awake()
    {
        Collided = false;
        gameObject.GetComponent<SpriteRenderer>().color = GameManager.ShootingBallColor;
        float sa = GetComponent<TrailRenderer>().startColor.a;
        float ea = GetComponent<TrailRenderer>().endColor.a;
        Color _color = GameManager.ShootingBallColor;
        Color sc = new Color(_color.r, _color.g, _color.b, sa);
        Color ec = new Color(_color.r, _color.g, _color.b, ea);
        gameObject.GetComponent<TrailRenderer>().startColor = sc;
        gameObject.GetComponent<TrailRenderer>().endColor = ec;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Collided = true;
            Instantiate(popUpText, collision.GetContact(0).point, Quaternion.identity);
            AudioManager.instance.Play("paint" + Random.Range(1,4));

            if (added == false)
            {
                NoofBalls.ballsPlayerHave += 1;
                added = true;
            }
            if (SlowDown)
            {
                if (TimeManager.Instance.SlowDown == false)
                {
                    TimeManager.Instance.SlowDown = true;
                }
            }

            if (collision.gameObject.GetComponent<ObstacleName>().thisName == "wood" || collision.gameObject.GetComponent<ObstacleName>().thisName == "arrow")
            {
                Destroy(collision.gameObject);
                Transform ps = Instantiate(blockHit_PS, collision.GetContact(0).point + Vector2.up * .35f, blockHit_PS.rotation);
                var p = ps.GetComponent<ParticleSystem>().main;
                p.startColor = GetComponent<SpriteRenderer>().color;

                Score.score += 1;

                createPieces(collision);
            }
            else if(collision.gameObject.GetComponent<ObstacleName>().thisName == "semicircle")
            {
                Destroy(collision.gameObject);
                Transform ps = Instantiate(blockHit_PS, collision.GetContact(0).point + Vector2.up * .35f, blockHit_PS.rotation);
                var p = ps.GetComponent<ParticleSystem>().main;
                p.startColor = GetComponent<SpriteRenderer>().color;

                Score.score += 1;

                createPieces(collision);
            }

            else if (collision.gameObject.GetComponent<ObstacleName>().thisName == "shooter")
            {
                //Destroy(collision.gameObject);
                Transform P = Instantiate(blockHit_PS, collision.GetContact(0).point + Vector2.up * .35f, blockHit_PS.rotation);
                var PS = P.GetComponent<ParticleSystem>().main;
                PS.startColor = GetComponent<SpriteRenderer>().color;

                GameObject pain = Instantiate(Paint, collision.GetContact(0).point + Vector2.up * 0.2f, Quaternion.Euler(0, 0, Random.Range(-360, 360)));
                pain.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                if (collision.gameObject.GetComponent<Animator>() != null)
                {
                    collision.gameObject.GetComponent<Animator>().SetTrigger("destroy");
                }
                pain.transform.SetParent(collision.transform);
                pain.transform.localScale = Vector2.one * PaintScale;
                Destroy(collision.gameObject, 1);


                Score.score += 1;

                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Respawn")
        {
            AudioManager.instance.Play("bounce");
            bouncy++;
            Transform ps = Instantiate(bouncerHit_PS, collision.GetContact(0).point, bouncerHit_PS.rotation);
            var p = ps.GetComponent<ParticleSystem>().main;
            p.startColor = GameManager.ShootingBallColor;
            if (CameraMovement.ShouldShake == false)
            {
                CameraMovement.ShouldShake = true;
            }
            if(bouncy > 1)
            {
                Destroy(gameObject);
            }
        }
    }
    #region CreatePieceOld
    //void CreatePieces(Collision2D collision)
    //{
    //    LeftSide = Instantiate(collision.gameObject.GetComponent<Block>().Left, collision.transform.position, collision.transform.rotation);
    //    RightSide = Instantiate(collision.gameObject.GetComponent<Block>().Right, collision.transform.position, collision.transform.rotation);

    //    Vector2 leftDir = (new Vector2(LeftSide.transform.position.x, LeftSide.transform.position.y) - collision.GetContact(0).point).normalized + Vector2.up * Random.Range(upwardForceMin,upwardForceMax +1);
    //    Vector2 rightDir = (new Vector2(RightSide.transform.position.x, RightSide.transform.position.y) - collision.GetContact(0).point).normalized + Vector2.up * Random.Range(upwardForceMin, upwardForceMax + 1);

    //    LeftSide.GetComponent<Rigidbody2D>().AddForce(leftDir * Random.Range(explosionForceMin,explosionForceMax + 1), ForceMode2D.Impulse);
    //    RightSide.GetComponent<Rigidbody2D>().AddForce(rightDir * Random.Range(explosionForceMin, explosionForceMax + 1), ForceMode2D.Impulse);

    //    if ((LeftSide.transform.position.x + transform.position.x) < LeftSide.transform.position.x)
    //    {
    //        LeftSide.GetComponent<Rigidbody2D>().AddTorque(explosionForceMax * 3);
    //        RightSide.GetComponent<Rigidbody2D>().AddTorque(-explosionForceMin * 3);
    //    }
    //    else
    //    {
    //        LeftSide.GetComponent<Rigidbody2D>().AddTorque(-explosionForceMax * 3);
    //        RightSide.GetComponent<Rigidbody2D>().AddTorque(explosionForceMin * 3);
    //    }

    //    GameObject p1 = Instantiate(Paint, collision.GetContact(0).point + new Vector2(0, collision.transform.up.y * .1f), Quaternion.Euler(0, 0, Random.Range(-360, 360)));
    //    GameObject p2 = Instantiate(Paint, collision.GetContact(0).point + new Vector2(0, collision.transform.up.y * .1f), Quaternion.Euler(0, 0, Random.Range(-360, 360)));

    //    p1.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
    //    p2.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;

    //    p1.transform.SetParent(LeftSide.transform);
    //    p2.transform.SetParent(RightSide.transform);

    //    p1.transform.localScale = Vector2.one * (PaintScale+0.5f);
    //    p2.transform.localScale = Vector2.one * (PaintScale+0.5f);

    //    Destroy(gameObject);
    //}
    #endregion CreatePieceOld

    void createPieces(Collision2D collision)
    {
        for(int i = 0;i < collision.gameObject.GetComponent<Block>().pieces.Length; i++)
        {
            GameObject piece = Instantiate(collision.gameObject.GetComponent<Block>().pieces[i], collision.transform.position, collision.transform.rotation);
            piece.transform.localScale = collision.gameObject.transform.localScale;
            Vector2 forceDir = (new Vector2(piece.transform.position.x, piece.transform.position.y) - collision.GetContact(0).point).normalized + Vector2.up * Random.Range(upwardForceMin, upwardForceMax + 1);
            piece.GetComponent<Rigidbody2D>().AddForce(forceDir * Random.Range(explosionForceMin, explosionForceMax + 1), ForceMode2D.Impulse);

            if(piece.GetComponent<Collider2D>().bounds.center.x < collision.GetContact(0).point.x)
            {
                piece.GetComponent<Rigidbody2D>().AddTorque(Random.Range(explosionForceMin,explosionForceMax + 1) * 3);
            }

            else
            {
                piece.GetComponent<Rigidbody2D>().AddTorque(-Random.Range(explosionForceMin, explosionForceMax + 1) * 3);
            }

            GameObject pt = Instantiate(Paint, collision.GetContact(0).point + new Vector2(0, collision.transform.up.y * .1f), Quaternion.Euler(0, 0, Random.Range(-360, 360)));
            pt.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            pt.transform.SetParent(piece.transform);
            pt.transform.localEulerAngles = Vector2.one * (PaintScale);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "sweetballs")
        {
            NoofBalls.ballsPlayerHave += collision.gameObject.GetComponent<ballsIncreaser>().balltoIncrease;
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        if (Collided == false)
        {
            NoofBalls.isPerfect = false;
        }
    }
}
