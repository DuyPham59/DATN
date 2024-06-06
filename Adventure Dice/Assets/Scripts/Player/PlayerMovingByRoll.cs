using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingByRoll : PlayerMoving
{
    protected override void GrassPos()
    {
        grassPos = grassPos + 1;      
    }

    protected override int NumberDice()
    {
        return PlayerRollToMove.instance.RandomDice;
    }

    protected override void CheckEndTurn()
    {
        //gameObject.SetActive(false);
        //if (Boss1.instance.CollisionPlayer) return;
        //Turn.instance.PlayerTurn = false;
    }
}
