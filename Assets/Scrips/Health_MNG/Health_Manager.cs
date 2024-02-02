using System.Collections;
using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] Material Death;
    [SerializeField] SkinnedMeshRenderer bodySkin;
    [SerializeField] dragPlayer _dragPlayer;
    private void Start()
    {
        _dragPlayer = FindObjectOfType<dragPlayer>();
    }



    public void TakeDamage(float value)
    {
        Health -= value;
        if (Health < 0)
        {
            bodySkin.material = Death;
            if (!GameManager.instance.is_Player_Death)
            {
                Handheld.Vibrate();
                StartCoroutine(UI_Manager.instance.NextLevel());
            }
            GameManager.instance.is_Player_Death = true;
            if (_dragPlayer)
            {
                _dragPlayer.SetValueToRig(20);
            }

            // death

        }


    }



}
