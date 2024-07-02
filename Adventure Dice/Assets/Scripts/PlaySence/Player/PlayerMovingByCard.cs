public class PlayerMovingByCard : PlayerMoving
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void GrassPos(int i)
    {
        if (CardManager.instance.NameCard == "Up")
        {
            grassPos = PosPlayer.instance.pos + i;
        }
        else if (CardManager.instance.NameCard == "Down")
        {
            grassPos = PosPlayer.instance.pos - i;
        }
    }

    protected override int NumberDice()
    {
        return CardManager.instance.NumberCard;
    }
}
