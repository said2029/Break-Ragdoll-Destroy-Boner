using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] Material Death;
    [SerializeField] SkinnedMeshRenderer bodySkin;

    public void TakeDamage(float value)
    {
        Health -= value;
        if (Health < 0)
        {
            bodySkin.material = Death;
            // death
        }

    }


}
