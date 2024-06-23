using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosPlayer : MonoBehaviour
{
    public int pos;
    public static PosPlayer instance;

    private void Awake()
    {
        pos = 0;
        PosPlayer.instance = this;
    }
}
