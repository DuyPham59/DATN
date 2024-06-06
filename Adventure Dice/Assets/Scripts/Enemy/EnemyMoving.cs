using System.Collections;
using UnityEngine;

public abstract class EnemyMoving : Move
{
    private bool enemyDown;
    private bool finishMoving;
    private bool enemyIsMoving;

    //public static EnemyMoving instance;
    //public bool FinishMoving => finishMoving;

    //public bool EnemyDown { get => enemyDown; set => enemyDown = value; }
    //public bool EnemyIsMoving { get => enemyIsMoving; set => enemyIsMoving = value; }

    protected override void Awake()
    {
        base.Awake();
        //EnemyMoving.instance = this;
        enemyIsMoving = true;
    }
    protected void Update()
    {
        StartCoroutine(StepEnemy());
        Moving();
    }

    public IEnumerator StepEnemy()
    {
        if (!enemyIsMoving /*&& !Turn.instance.PlayerTurn*/) StopCoroutine(StepEnemy());
        enemyIsMoving = false;
        //finishMoving = false;
        for (int i = 1; i <= NumberDice(); i++)
        {
            jump.SetTrigger("IsJump");
            GrassPos();
            posTarget = Map.Instance.Grass[grassPos];
            yield return new WaitForSeconds(1);
            if (grassPos == 0) break;
        }
        CheckEndTurn();
        //finishMoving = true;
        //EnemyMoving.instance.EnemyDown = false;     

    }

    protected abstract void GrassPos();
    //{
    //    if(!enemyDown) { grassPos = grassPos + 1; }
    //    else
    //    {
    //        grassPos = grassPos - 1;
    //    }       
    //}

    protected abstract int NumberDice();

    protected abstract void CheckEndTurn();
}
