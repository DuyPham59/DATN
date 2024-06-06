using UnityEngine;

public class EnemyMovingByRoll : EnemyMoving
{
    protected override void GrassPos()
    {
        grassPos = grassPos + 1;
    }

    protected override int NumberDice()
    {
        return Random.Range(1, 7);
    }

    protected override void CheckEndTurn()
    {
        //gameObject.SetActive(false);
        //if (Boss1.instance.CollisionEnemy) return;
        //Turn.instance.PlayerTurn = true;
    }
}
