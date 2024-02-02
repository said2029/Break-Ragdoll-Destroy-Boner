using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class dragPlayer : MonoBehaviour
{
    [SerializeField] int positionSpring;
    [SerializeField] Transform PlayerLimit_Z;
    [SerializeField] Vector3 LimitValue;


    [SerializeField] ConfigurableJoint[] configurableJoints;
    [SerializeField] ConfigurableJoint HipsConfigurableJoints;

    JointDrive j;

    private void Start()
    {
        LimitValue.z = PlayerLimit_Z.position.z;
        SetValueToRig(positionSpring);
    }
    private void Update()
    {
        PlayerLimit_Z.position = new Vector3(PlayerLimit_Z.position.x, PlayerLimit_Z.position.y, LimitValue.z);

        LimitPlayer();

    }
    public void Drag()
    {
        SetValueToRig(20);
        if (!GameManager.instance.is_Player_Death)
            StartCoroutine(RestartRigs());

    }

    IEnumerator RestartRigs()
    {
        yield return new WaitForSeconds(7);
        SetValueToRig(4000);
    }

    void LimitPlayer()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(PlayerLimit_Z.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        PlayerLimit_Z.position = Camera.main.ViewportToWorldPoint(pos);
    }



    public void SetValueToRig(int value)
    {
        foreach (var conf in configurableJoints)
        {
            j = conf.angularXDrive;
            j.positionSpring = value;
            conf.angularXDrive = j;
            conf.angularYZDrive = j;

        }

    }
}
