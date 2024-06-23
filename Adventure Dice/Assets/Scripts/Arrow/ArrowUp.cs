using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUp : MonoBehaviour
{
    private int posArrow;

    private void Awake()
    {
        PosArrow();
    }

    private void Update()
    {
        CheckArrow();
    }

    void PosArrow()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posArrow = i;
                break;
            }
        }
    }

    void CheckArrow()
    {
        if (posArrow == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving())
        {
            MovingManager.instance.ActivePlayerMovingByName("PlayerMoveUpRandom");
            Destroy(gameObject);
            Debug.Log("Run");
        }
        else if (posArrow == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() )
        {
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMoveUpRandom");
            Destroy(gameObject);
        }
    }
}
