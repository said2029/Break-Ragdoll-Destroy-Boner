using UnityEngine;

public class Call_hh : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] Health_Manager _Health_Manager;

    // fall damage
    Vector3 enterPos, exitPos;
    void Start()
    {
        _Health_Manager = FindObjectOfType<Health_Manager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print("Enter");
            enterPos = transform.position;
            _Health_Manager.TakeDamage(damage * exitPos.y - enterPos.y);
        }
    }


    // private void OnTriggerEnter(Collider other)
    // {
    // }
    void OnCollisionExit(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                {
                    print("Exit");
                    exitPos = transform.position;

                    break;
                }
        }

    }
}
