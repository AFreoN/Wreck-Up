using UnityEngine;

public class BGSpotSetter : MonoBehaviour
{
    float init;
    public Transform Player;

    void Start()
    {
        init = Player.position.y;
    }
    void LateUpdate()
    {
        if (GameManager.StartGame == true)
        {
            if (init + 21.6f <= Player.position.y)
            {
                init = Player.position.y;
                transform.position = new Vector3(0 , Player.position.y , 0);
            }
        }
    }
}
