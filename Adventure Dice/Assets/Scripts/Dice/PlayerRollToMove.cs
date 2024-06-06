using System.Collections;

public class PlayerRollToMove : RollDice
{
    public static PlayerRollToMove instance;
    private bool completeRollToMove;

    public bool CompleteRollToMove { get => completeRollToMove; set => completeRollToMove = value; }

    private void Awake()
    {
        PlayerRollToMove.instance = this;
    }

    public override IEnumerator BouncyDice()
    {
        yield return base.BouncyDice();
        completeRollToMove = true;
    }
}
