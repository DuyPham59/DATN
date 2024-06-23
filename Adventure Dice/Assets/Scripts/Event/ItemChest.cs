using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    private int posItemCoffer;

    private void Awake()
    {
        PosArrow();
    }

    private void Update()
    {
        CheckItemCoffer();
    }

    void PosArrow()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posItemCoffer = i;
                break;
            }
        }
    }

    void CheckItemCoffer()
    {

        if (posItemCoffer == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving())
        {
            CardManager.instance.addCard("Player");
            Destroy(gameObject);
            Debug.Log("Run");
        }
        else if (posItemCoffer == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving())
        {
            CardManager.instance.addCard("Enemy");
            Destroy(gameObject);
            Debug.Log("Run");
        }
    }
}
