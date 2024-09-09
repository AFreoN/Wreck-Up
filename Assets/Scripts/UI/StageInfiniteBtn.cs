using UnityEngine;

public class StageInfiniteBtn : MonoBehaviour
{
    public GameObject TickImg;

    public buttonType ButtonType;
    bool value;

    void Start()
    {
        if(ButtonType == buttonType.EndlessBtn)
        {
            if(PlayerPrefs.GetInt("type") == 1)
            {
                TickImg.SetActive(true);
            }
            else
            {
                TickImg.SetActive(false);
            }
        }

        else if(ButtonType == buttonType.StageButton)
        {
            if(PlayerPrefs.GetInt("type") == 0)
            {
                TickImg.SetActive(true);
            }
            else
            {
                TickImg.SetActive(false);
            }
        }

        value = GameManager.instance.isInfinite;
    }

    private void Update()
    {
        if(ButtonType == buttonType.StageButton && GameManager.instance.isInfinite != value)
        {
            StageBtn();
        }
        else if(ButtonType == buttonType.EndlessBtn && GameManager.instance.isInfinite != value)
        {
            InfiniteBtn();
        }
    }

    public void StageBtn()
    {
        TickImg.SetActive(!GameManager.instance.isInfinite);

        value = GameManager.instance.isInfinite;
    }

    public void InfiniteBtn()
    {
        TickImg.SetActive(GameManager.instance.isInfinite);

        value = GameManager.instance.isInfinite;
    }

    public void StageInfiniteTriggerBtn()
    {
        AudioManager.instance.Play("lid");
        if(ButtonType == buttonType.StageButton)
        {
            GameManager.instance.isInfinite = false;
            PlayerPrefs.SetInt("type", 0);
        }
        else if(ButtonType == buttonType.EndlessBtn)
        {
            GameManager.instance.isInfinite = true;
            PlayerPrefs.SetInt("type", 1);
        }
    }

    public enum buttonType
    {
        StageButton,
        EndlessBtn
    }
}
