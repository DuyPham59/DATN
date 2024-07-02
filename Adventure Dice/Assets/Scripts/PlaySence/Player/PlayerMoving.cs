using System.Collections;
using UnityEngine;

public abstract class PlayerMoving : Move
{
    protected bool playerLoseBoss;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(StepPlayer());
    }

    protected void Update()
    {
        Moving();
    }

    protected IEnumerator StepPlayer()
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
        PosPlayer.instance.pos = grassPos;
        gameObject.SetActive(false);
    }

    protected abstract void GrassPos(int i);

    protected abstract int NumberDice();
}
