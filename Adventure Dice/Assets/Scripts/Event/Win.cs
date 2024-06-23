using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Win : MonoBehaviour
{
    private void Update()
    {
        if(PosPlayer.instance.pos == (Map.Instance.Grass.Count - 1))
        {

        }
        else if(PosEnemy.instance.pos == (Map.Instance.Grass.Count -1))
        {

        }
    }
}
