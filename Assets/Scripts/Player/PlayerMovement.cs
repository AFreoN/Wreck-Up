using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10;

    public float SideSpeed = 50f;
    public float MaxDis = 3f;
    bool right;

    public TextMesh ballsText;
    public SpriteRenderer Aura;

    public GameObject destroyParticles;

    public GameObject StageEnd_PS;
    public Transform PartyPS_GY, PartyPS_BR;

    public GameObject MainCamera;

    Rigidbody2D rb;
    Color PlayerColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballsText.transform.GetComponent<Renderer>().sortingLayerID = this.transform.GetComponent<Renderer>().sortingLayerID;

        PlayerColor = GetComponent<SpriteRenderer>().color;

        right = Random.Range(0, 2) == 0 ? true : false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(PlayerColor != GameManager.ShootingBallColor)
        {
            PlayerColor = GameManager.ShootingBallColor;
            GetComponent<SpriteRenderer>().color = PlayerColor;
            Aura.color = PlayerColor;
        }
    }

    void FixedUpdate()
    {
        if (GameManager.dead == false && GameManager.StartGame == true)
        {
            if(right == true)
            {
                if (transform.position.x < MaxDis)
                {
                    rb.velocity = Vector2.right * SideSpeed * Time.fixedDeltaTime + Vector2.up * Speed * Time.fixedDeltaTime;
                }
                else
                {
                    right = false;
                }
            }
            else if(right == false)
            {
                if(transform.position.x > -MaxDis)
                {
                    rb.velocity = Vector2.left * SideSpeed * Time.fixedDeltaTime + Vector2.up * Speed * Time.fixedDeltaTime;
                }
                else
                {
                    right = true;
                }
            }
        }
        else if(transform.position.x != 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), .1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle" || collision.gameObject.tag == "wood")
        {
            GameManager.instance.GameOver();
            gameObject.SetActive(false);
            GameObject dp = Instantiate(destroyParticles, transform.position, transform.rotation);
            var ps = dp.GetComponent<ParticleSystem>().main;
            ps.startColor = GameManager.ShootingBallColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Instantiate(StageEnd_PS, transform.position, StageEnd_PS.transform.rotation);
            if (NoofBalls.isPerfect == true)
            {
                Instantiate(PartyPS_BR, new Vector3(-5.4f, collision.transform.position.y, 0), PartyPS_BR.rotation);
                Instantiate(PartyPS_GY, new Vector3(5.4f, collision.transform.position.y, 0), PartyPS_GY.rotation);
            }
            GameManager.instance.StageFinished();
            MainCamera.GetComponent<CameraMovement>().Zoom = true;
            Invoke("Loadnext", 1.5f);
        }
    }

    void Loadnext()
    {
        GameManager.instance.LoadMainMenu();
    }
}
