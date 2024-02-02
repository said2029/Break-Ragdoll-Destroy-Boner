using UnityEngine;

public class LimitCameraOpjects : MonoBehaviour
{
    Camera Cam;
    void Start()
    {
        Cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posLimit = Cam.WorldToViewportPoint(transform.position);
        posLimit.x = Mathf.Clamp01(posLimit.x);
        posLimit.y = Mathf.Clamp01(posLimit.y);
        transform.position = Cam.ViewportToWorldPoint(posLimit);
    }
}
