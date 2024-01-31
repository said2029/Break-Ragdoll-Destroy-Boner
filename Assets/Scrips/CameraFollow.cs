using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] bool Can_Follow = false;
    [SerializeField] Transform Traget;
    [SerializeField] Vector3 offset;

    [SerializeField] float SmoothMove;



    void Update()
    {
        if (Can_Follow && Traget != null)
        {

            transform.position = Vector3.Lerp(transform.position, Traget.position + offset, SmoothMove * Time.deltaTime);
        }

    }

}
