using UnityEngine;

public class limitDrag : MonoBehaviour
{
    [SerializeField] bool limitx, limity, limitz;
    Vector3 limits;



    void Start()
    {
        limits = transform.position;
    }

    void Update()
    {
        if (limitx)
        {
            limit(new Vector3(limits.x, transform.position.y, transform.position.z));



        }
        if (limity)
        {
            limit(new Vector3(limits.x, limits.y, transform.position.z));

        }
        if (limity)
        {
            limit(new Vector3(limits.x, transform.position.y, limits.z));
        }
    }

    void limit(Vector3 vv)
    {
        transform.position = vv;

    }
}
