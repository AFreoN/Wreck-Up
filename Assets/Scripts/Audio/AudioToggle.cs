using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public GameObject SoundON;
    public GameObject SoundOFF;

    void Awake()
    {
        if(PlayerPrefs.HasKey("audio") == false)
        {
            PlayerPrefs.SetInt("audio", 1);
        }

        if(PlayerPrefs.GetInt("audio") == 1)
        {
            SoundON.SetActive(true);
            SoundOFF.SetActive(false);
        }
        else
        {
            SoundON.SetActive(false);
            SoundOFF.SetActive(true);
        }
    }

    public void toggleAudio()
    {
        if(PlayerPrefs.GetInt("audio") == 1)
        {
            PlayerPrefs.SetInt("audio", 0);
            SoundON.SetActive(false);
            SoundOFF.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("audio", 1);
            SoundON.SetActive(true);
            SoundOFF.SetActive(false);
        }
    }
}
