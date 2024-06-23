using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingByCard : EnemyMoving
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void GrassPos(int i)
    {
        if (CardManager.instance.NameCard == "Up")
        {
            grassPos = PosEnemy.instance.pos + i;
        }
        else if (CardManager.instance.NameCard == "Down")
        {
            grassPos = PosEnemy.instance.pos - i;
        }
    }

    protected override int NumberDice()
    {
        return CardManager.instance.NumberCard;
    }
}
