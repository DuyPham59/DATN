using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitTrap : PlayerMoving
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void GrassPos(int i)
    {
        grassPos = PosPlayer.instance.pos + i;
    }

    protected override int NumberDice()
    {
        return PlayerRollExitTrap.instance.RandomDice;
    }
}
