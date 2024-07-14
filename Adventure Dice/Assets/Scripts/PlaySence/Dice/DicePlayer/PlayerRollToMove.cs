using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRollToMove : RollDice
{
    public static PlayerRollToMove instance;
    public bool doubleMove;
    public bool completeRoll;
    [SerializeField] private Text textDouble;

    private void Awake()
    {
        completeRoll = true;
        PlayerRollToMove.instance = this;
    }

    public override IEnumerator BouncyDice()
    {
        completeRoll = false;
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
        completeRoll = true;
        MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByRoll");
    }
}
