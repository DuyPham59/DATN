using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDownRandom : EnemyMoving
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void GrassPos(int i)
    {
        grassPos = PosEnemy.instance.pos - i;
    }

    protected override int NumberDice()
    {
        return Random.Range(1, 7);
    }
}
