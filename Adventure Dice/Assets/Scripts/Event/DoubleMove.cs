using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMove : MonoBehaviour
{
    private int posDoubleMove;

    private void Awake()
    {
        PosDoubleMove();
    }

    private void Update()
    {
        CheckDoubleMove();
    }

    void PosDoubleMove()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posDoubleMove = i;
                break;
            }
        }
    }

    void CheckDoubleMove()
    {
        if (posDoubleMove == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving())
        {
            PlayerRollToMove.instance.doubleMove = true;
            Destroy(gameObject);
        }
        else if (posDoubleMove == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving())
        {
            EnemyRollToMove.instance.doubleMove = true;
            Destroy(gameObject);
        }
    }
}
