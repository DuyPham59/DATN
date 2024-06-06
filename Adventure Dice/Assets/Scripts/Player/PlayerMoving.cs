using System.Collections;
using UnityEngine;

public abstract class PlayerMoving : Move
{
    protected bool playerLoseBoss;
    protected bool playerIsMoving;
    protected bool finishMoving;

    //public static PlayerMoving instance;

    //public bool FinishMoving => finishMoving;

    //public bool PlayerIsMoving { get => playerIsMoving; set => playerIsMoving = value; }
    //public bool PlayerLoseBoss { get => playerLoseBoss; set => playerLoseBoss = value; }

    protected override void Awake()
    {
        base.Awake();
        //PlayerMoving.instance = this;
        playerIsMoving = true;
    }

    protected void Update()
    {
        StartCoroutine(StepPlayer());
        Moving();
    }
    protected IEnumerator StepPlayer()
    {
        if (!playerIsMoving) { StopCoroutine(StepPlayer()); }
        playerIsMoving = false;
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
        //RollDice.instance.CompleteRoll = false;
        //finishMoving = true;
    }

    protected abstract void GrassPos();
    //{
    //    if (playerLoseBoss)
    //    {
    //        grassPos = grassPos - 1;
    //        return grassPos;
    //    }
    //    else
    //    {
    //        grassPos = grassPos + 1;
    //        return grassPos;
    //    }
    //}

    protected abstract int NumberDice();
    //{
    //    if (playerLoseBoss)
    //    {
    //        int diceNumber = Random.Range(1, 7);
    //        return diceNumber;
    //    }
    //    else
    //    {
    //        int diceNumber = RollDice.intance.RandomDice;
    //        return diceNumber;
    //    }
    //}
    protected abstract void CheckEndTurn();
}
