public class PlayerMovingByRoll : PlayerMoving
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
        return PlayerRollToMove.instance.RandomDice;
    }
}
