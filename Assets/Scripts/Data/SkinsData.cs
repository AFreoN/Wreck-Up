using UnityEngine;

public class SkinsData : MonoBehaviour
{
    [HideInInspector]
    public Color SkinColor;

    public Transform ColorParent;
    public Transform SelectedHighlighter;

    bool StartMove = false;
    public float LerpSpeed = .35f;

    void Start()
    {
        if(PlayerPrefs.HasKey("skin") == false)
        {
            PlayerPrefs.SetInt("skin", 2);
        }
        SkinsColor(PlayerPrefs.GetInt("skin"));

        SelectedHighlighter.SetParent(ColorParent.GetChild(PlayerPrefs.GetInt("skin") - 1));
        SelectedHighlighter.localPosition = Vector3.zero;
        SelectedHighlighter.localScale = Vector3.one;
    }

    public void ColorButtonsClick(int SkinNum)
    {
        PlayerPrefs.SetInt("skin", SkinNum);
        AudioManager.instance.Play("play");
        SkinsColor(PlayerPrefs.GetInt("skin"));
    }

    void SkinsColor(int s)
    {
        switch(s)
        {
            case 1:
                SkinColor = new Color32(255, 0, 0, 255);
                break;
            case 2:
                SkinColor = new Color32(255, 221, 0, 255);
                break;
            case 3:
                SkinColor = new Color32(0, 255, 22, 255);
                break;
            case 4:
                SkinColor = new Color32(15, 0, 255, 255);
                break;
            case 5:
                SkinColor = new Color32(255, 104, 0, 255);
                break;
            case 6:
                SkinColor = new Color32(255, 0, 196, 255);
                break;
            case 7:
                SkinColor = new Color32(135, 31, 0, 255);
                break;
            case 8:
                SkinColor = new Color32(0, 253, 255, 255);
                break;
            case 9:
                SkinColor = new Color32(255, 255, 255, 255);
                break;
            case 10:
                SkinColor = new Color32(142, 0, 183, 255);
                break;
            case 11:
                SkinColor = new Color32(0, 106, 6, 255);
                break;
            case 12:
                SkinColor = new Color32(0, 97, 106, 255);
                break;
            case 13:
                SkinColor = new Color32(155, 0, 77, 255);
                break;
            case 14:
                SkinColor = new Color32(144, 144, 144, 255);
                break;
            case 15:
                SkinColor = new Color32(87, 81, 0, 255);
                break;
        }
        GameManager.ShootingBallColor = SkinColor;

        SelectedHighlighter.SetParent(ColorParent.GetChild(s - 1));
        //SelectedHighlighter.localPosition = Vector3.zero;
        //SelectedHighlighter.localScale = Vector3.one;

        StartMove = true;
    }

    void Update()
    {
        if(StartMove && SelectedHighlighter.localPosition != Vector3.zero)
        {
            SelectedHighlighter.localPosition = Vector3.Lerp(SelectedHighlighter.transform.localPosition, Vector3.zero, LerpSpeed);
        }
        else if(SelectedHighlighter.localPosition == Vector3.zero)
        {
            StartMove = false;
        }
    }
}
