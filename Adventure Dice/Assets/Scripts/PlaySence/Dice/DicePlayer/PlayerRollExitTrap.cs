using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollExitTrap : RollDice
{
    public static PlayerRollExitTrap instance;
    private bool completeRollExitTrap;

    public bool CompleteRollExitTrap { get => completeRollExitTrap; set => completeRollExitTrap = value; }

    private void Awake()
    {
        PlayerRollExitTrap.instance = this;
    }

    public override IEnumerator BouncyDice()
    {
        yield return base.BouncyDice();
        completeRollExitTrap = true;
    }
}
