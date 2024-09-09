using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Player;

    [Header("SpawnDis")]
    public float SpawnDis = 5f;
    public float noofSpawn = 3;

    [Header("Obstacles")]
    public Transform obstacle1;
    public Transform obstacle2;
    public Transform Shooter;
    public Transform circle1;
    public Transform circle2;
    public Transform triangle;
    public Transform arrow;
    public Transform twojoints;

    public float Xmax = 1.5f;
    public float Move_Variation = 50;
    int[] SpawnProbabilities = { 1, 1, 1, 2, 2, 2, 3,4,4,5,5,6,6,7,8};

    [Header("Sweet Balls")]
    public Transform SweetBalls;
    public int SpawnChance = 3;

    float curSpawnedDis , startYpos;
    bool StartSpawn = false;

    void Start()
    {
        startYpos = Player.position.y + (SpawnDis * (noofSpawn-1));
    }
    void Update()
    {
        if(GameManager.StartGame == true && StartSpawn == false)
        {
            StartSpawn = true;

            for (int i = 0; i < noofSpawn; i++)
            {
                int r = SpawnProbabilities[Random.Range(0, SpawnProbabilities.Length)];
                Spawn(r);
            }

            int sb = Random.Range(0, SpawnChance);
            if (sb == 0)
            {
                Instantiate(SweetBalls, new Vector2(Random.Range(-Xmax, Xmax), startYpos - 2), Quaternion.identity);
            }
        }

        if(GameManager.dead == false && Player.position.y >= startYpos)
        {
            for (int i = 0; i < noofSpawn; i++) 
            {
                int r = SpawnProbabilities[Random.Range(0, SpawnProbabilities.Length)];
                Spawn(r);
            }
            startYpos += (SpawnDis * (noofSpawn-1));

            int sb = Random.Range(0, SpawnChance);
            if (sb == 0)
            {
                Instantiate(SweetBalls, new Vector2(Random.Range(-Xmax, Xmax), curSpawnedDis - 2), Quaternion.identity);
            }
        }
    }

    void Spawn(int r)
    {
        switch(r)
        {
            case 1:
                int[] r1 = { -270, -180, -90, 0, 90, 180, 270 };
                Transform obs1 = Instantiate(obstacle1, new Vector2(Random.Range(-Xmax, Xmax + 1), curSpawnedDis + SpawnDis), Quaternion.Euler(0,0,r1[Random.Range(0,r1.Length)]));
                float move1 = obs1.GetComponent<HVmovement>().MovementSpeed;
                obs1.GetComponent<HVmovement>().MovementSpeed = Random.Range(move1 - Move_Variation, move1 + Move_Variation);

                //For changing movement Direction
                if(Random.Range(0,2) == 0)
                {
                    obs1.GetComponent<HVmovement>().Movement = HVmovement.MovementType.Vertical;
                }
                if (Random.Range(0, 2) == 0)
                {
                    obs1.GetComponent<HVmovement>().isMovable = true;
                }
                //For changin Rotation Direction
                if(Random.Range(0, 2) == 0)
                {
                    obs1.GetComponent<HVmovement>().Rotation = HVmovement.RotationType.AntiClockwise;
                }
                if(!obs1.GetComponent<HVmovement>().isMovable)
                {
                    obs1.GetComponent<HVmovement>().isRotatable = true;
                }
                curSpawnedDis += SpawnDis;
                break;

            case 2:
                int[] r2 = { -270, -180, -90, 0, 90, 180, 270 };
                Transform obs2 = Instantiate(obstacle2, new Vector2(Random.Range(-Xmax, Xmax + 1), curSpawnedDis + SpawnDis), Quaternion.Euler(0,0,r2[Random.Range(0,r2.Length)]));
                float move2 = obs2.GetComponent<HVmovement>().MovementSpeed;
                obs2.GetComponent<HVmovement>().MovementSpeed = Random.Range(move2 - Move_Variation, move2 + Move_Variation);

                //For changing Movement DIrection
                if (Random.Range(0, 2) == 0)
                {
                    obs2.GetComponent<HVmovement>().Movement = HVmovement.MovementType.Vertical;
                }

                if (Random.Range(0, 2) == 0)
                {
                    obs2.GetComponent<HVmovement>().isMovable = true;
                }
                //For changing ROtation Direction
                if(Random.Range(0, 2) == 0)
                {
                    obs2.GetComponent<HVmovement>().Rotation = HVmovement.RotationType.AntiClockwise;
                }
                if(!obs2.GetComponent<HVmovement>().isMovable)
                {
                    obs2.GetComponent<HVmovement>().isRotatable = true;
                }

                curSpawnedDis += SpawnDis;
                break;

            case 3:
                float ran = Random.Range(0, 2) == 0 ? -Xmax-0.3f : Xmax+ 0.3f;
                Transform t = Instantiate(Shooter, new Vector2(ran, curSpawnedDis + SpawnDis), Quaternion.identity);

                if(t.position.x < 0)
                {
                    t.rotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    t.rotation = Quaternion.Euler(0, 0, 90);
                }

                curSpawnedDis += SpawnDis;
                break;
            case 4:
                if(Random.Range(0,2) == 1)
                {
                    int c1angle = Random.Range(0, 2) == 0 ? 180 : 0;
                    Transform c1 = Instantiate(circle1, new Vector2(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0,0,c1angle));
                }
                else
                {
                    Transform c1a = Instantiate(circle1, new Vector3(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0, 0, 0));
                    Transform c1b = Instantiate(circle1, new Vector3(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0, 0, 180));
                }
                curSpawnedDis += SpawnDis;
                break;
            case 5:
                if (Random.Range(0, 2) == 1)
                {
                    int c2angle = Random.Range(0, 2) == 0 ? 180 : 0;
                    Transform c2 = Instantiate(circle2, new Vector2(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0, 0, c2angle));
                }
                else
                {
                    Transform c2a = Instantiate(circle2, new Vector3(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0, 0, 0));
                    Transform c2b = Instantiate(circle2, new Vector3(0, curSpawnedDis + SpawnDis), Quaternion.Euler(0, 0, 180));
                }
                curSpawnedDis += SpawnDis;
                break;
            case 6:
                Transform tri = Instantiate(triangle, new Vector3(Random.Range(-Xmax, Xmax + 1), curSpawnedDis + SpawnDis),Quaternion.Euler(0,0,Random.Range(0, 360)));
                curSpawnedDis += SpawnDis;
                break;
            case 7:
                if(Random.Range(0,2) == 0)
                {
                    int arangle = Random.Range(1,3) == 1 ? 0 : 180;
                    Transform ar = Instantiate(arrow, new Vector3(Random.Range(-Xmax, Xmax), curSpawnedDis + SpawnDis, 0), Quaternion.Euler(0, 0, arangle));
                    curSpawnedDis += SpawnDis;
                }
                else
                {
                    Transform ar1 = Instantiate(arrow, new Vector3(Random.Range(-Xmax, Xmax + 1), curSpawnedDis + SpawnDis, 0), Quaternion.Euler(0, 0, 0));
                    curSpawnedDis += SpawnDis;
                    Transform ar2 = Instantiate(arrow, new Vector3(Random.Range(-Xmax, Xmax + 1), curSpawnedDis + SpawnDis, 0), Quaternion.Euler(0, 0, 180));
                    curSpawnedDis += SpawnDis;
                }
                break;
            case 8:
                Instantiate(twojoints, new Vector3(0, curSpawnedDis + SpawnDis, 0), Quaternion.identity);
                break;
        }
    }
}
