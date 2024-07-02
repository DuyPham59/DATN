public class EnemyExitTrap : EnemyMoving
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
        return EnemyRollExitTrap.instance.RandomDice;
    }
}
