using UnityEngine;

public class PosEnemy : MonoBehaviour
{
    public int pos;
    public static PosEnemy instance;

    private void Awake()
    {
        pos = 0;
        PosEnemy.instance = this;
    }
}
