using System.Collections;
using UnityEngine;

public abstract class EnemyMoving : Move
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected void OnEnable()
    {
        StartCoroutine(StepEnemy());
    }

    protected void Update()
    {
        Moving();
    }

    protected IEnumerator StepEnemy()
    {
        numberDice = NumberDice();
        for (int i = 1; i <= numberDice; i++)
        {
            ani.SetTrigger("Jump");
            GrassPos(i);
            posTarget = Map.Instance.Grass[grassPos];
            yield return new WaitForSeconds(1);
            if (grassPos == 0) break;
            else if (grassPos == (Map.Instance.Grass.Count - 1)) break;
        }
        PosEnemy.instance.pos = grassPos;
        gameObject.SetActive(false);
    }

    protected abstract void GrassPos(int i);

    protected abstract int NumberDice();
}
