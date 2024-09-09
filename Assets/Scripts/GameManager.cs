using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int LevelNumber = 1;

    public static bool dead = false;
    public static bool StartGame = false;

    public static Color ShootingBallColor;

    public GameObject EndlessInGamePanel;
    public GameObject StagedInGamePanel;
    public GameObject GameOverPanel;
    public GameObject StageFinishPanel;

    public GameObject RandomSpawner;

    [HideInInspector]
    public bool isInfinite = false;
    bool sceneLoaded = false;

    public Animator UIMaster;

    static GameObject ga;
    public GameObject gameAnaly;

    private void Awake()
    {
        instance = this;
        if(ga == null)
        {
            ga = Instantiate(gameAnaly, Vector3.zero, Quaternion.identity);
        }
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
        ShootingBallColor = Color.black;
        RandomSpawner.SetActive(isInfinite);
        StageFinishPanel.SetActive(false);
        if(PlayerPrefs.HasKey("Level") == false)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        if(PlayerPrefs.HasKey("highscore") == false)
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        if(PlayerPrefs.HasKey("type") == false)
        {
            PlayerPrefs.SetInt("type", 0);
            isInfinite = false;
        }
        if(PlayerPrefs.HasKey("audio") == false)
        {
            PlayerPrefs.SetInt("audio", 1);
        }
        isInfinite = PlayerPrefs.GetInt("type") == 1 ? true : false;

        AudioManager.instance.Play("camera");
        //PlayerPrefs.SetInt("Level", LevelNumber);
    }

    void Start()
    {
        StartSetter();
    }

    void StartSetter()
    {
        dead = false;
        StartGame = false;
        sceneLoaded = false;
        EndlessInGamePanel.SetActive(false);
        StagedInGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void setColor(Image img)
    {
        ShootingBallColor = img.GetComponent<Image>().color;
        ShootingBallColor = new Color32((byte)(ShootingBallColor.r * 255), (byte)(ShootingBallColor.g * 255), (byte)(ShootingBallColor.b * 255), (byte)(ShootingBallColor.a * 255));

        StartGame = true;

        if (isInfinite == false)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            StagedInGamePanel.SetActive(true);
        }
        else
        {
            EndlessInGamePanel.SetActive(true);
        }
    }

    public void StartGameBtn()
    {
        if (sceneLoaded == false)
        {
            sceneLoaded = true;
            StartGame = true;
            AudioManager.instance.Play("play");

            UIMaster.SetTrigger("main");
            EndlessInGamePanel.SetActive(isInfinite);
            StagedInGamePanel.SetActive(!isInfinite);
            RandomSpawner.SetActive(isInfinite);
            if (!isInfinite)
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("Level"), LoadSceneMode.Additive);
                //SceneManager.LoadScene(LevelNumber, LoadSceneMode.Additive);
            }
        }
    }

    public void GameOver()
    {
        dead = true;
        AudioManager.instance.Play("dead");
        GameOverPanel.SetActive(true);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StageFinished()
    {
        StartGame = false;
        StageFinishPanel.SetActive(true);
        PlayerPrefs.SetInt("Level", GameObject.Find("StartEndFeeder").GetComponent<EndPointFeeder>().LevelNo + 1);
        if (NoofBalls.isPerfect)
        {
            //TimeManager.Instance.SlowDown = true;
        }

        AudioManager.instance.Play("finish");
        //Invoke("LoadMainMenu", 2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OpenShopMenu()
    {
        UIMaster.SetBool("shop", !UIMaster.GetBool("shop"));
        if(UIMaster.GetBool("shop") == true)
        {
            AudioManager.instance.Play("click");
        }
        else
        {
            AudioManager.instance.Play("closeclick");
        }
        if (UIMaster.GetBool("shop") == true && UIMaster.GetBool("settings") == true)
        {
            UIMaster.SetBool("settings", false);
        }
    }

    public void SettingsMenu()
    {
        UIMaster.SetBool("settings", !UIMaster.GetBool("settings"));
        if(UIMaster.GetBool("settings") == true)
        {
            AudioManager.instance.Play("click");
        }
        else
        {
            AudioManager.instance.Play("closeclick");
        }
        if (UIMaster.GetBool("shop") == true && UIMaster.GetBool("settings") == true)
        {
            UIMaster.SetBool("shop", false);
        }
    }
}
