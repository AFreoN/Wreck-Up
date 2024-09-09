using UnityEngine;

public class TargetRot : MonoBehaviour
{
    public Transform Target;
    public float RotSpeed;

    Vector3 pos;

    void Start()
    {
        pos = Target.position;
    }
    void Update()
    {
        transform.RotateAround(pos, Vector3.forward, RotSpeed * Time.deltaTime);
    }
}
