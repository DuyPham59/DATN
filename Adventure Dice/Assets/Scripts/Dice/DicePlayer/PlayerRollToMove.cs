using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRollToMove : RollDice
{
    public static PlayerRollToMove instance;
    public bool doubleMove;
    [SerializeField] private Text textDouble;

    private void Awake()
    {
        PlayerRollToMove.instance = this;
    }

    public override IEnumerator BouncyDice()
    {
        if (doubleMove)
        {
            textDouble.gameObject.SetActive(true);
        }
        yield return base.BouncyDice();
        if (doubleMove)
        {
            doubleMove = false;
            textDouble.gameObject.SetActive(false);
            randomDice *= 2;
        }
        MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByRoll");
    }
}
