using UnityEngine;

public class EnemyMoveUpRandom : EnemyMoving
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void GrassPos(int i)
    {
        grassPos = PosEnemy.instance.pos + i;
    }

    protected override int NumberDice()
    {
        return Random.Range(1, 7);
    }
}
