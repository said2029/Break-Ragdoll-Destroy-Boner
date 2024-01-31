using UnityEngine;

public class LineRanaderpoints : MonoBehaviour
{
    [SerializeField] Transform[] PosPointas;
    [SerializeField] LineRenderer Line;
    void Start()
    {
        Line.positionCount = PosPointas.Length;

    }
    private void Update()
    {
        RanderLine();

    }

    void RanderLine()
    {
        for (int i = 0; i < PosPointas.Length; i++)
        {
            Line.SetPosition(i, PosPointas[i].position);
        }
    }



}


