using UnityEngine;

public class BGMovement : MonoBehaviour
{

    public Transform target;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        //if (GameManager.StartGame == true && GameManager.dead == false)
        //{
            transform.position = offset + new Vector3(0,target.position.y,0);
        //}
    }
}
