using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootingPoint;
    public float BulletSpeed = 20;

    public float SpawnRate = 1;

    bool isShootable = true;
    float t;

    void Start()
    {
        t = Time.time + SpawnRate;
    }
    void Update()
    {
        if (isShootable)
        {
            if (t > Time.time)
            {
                t -= Time.deltaTime;
            }
            else
            {
                t = Time.time + SpawnRate;
                GameObject b = Instantiate(Bullet, ShootingPoint.position, transform.rotation);
                b.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                Rigidbody2D rb = b.GetComponent<Rigidbody2D>();

                rb.AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
                Destroy(b, 2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball" && isShootable == true)
        {
            isShootable = false;
        }
    }
}
