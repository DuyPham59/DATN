using System.Collections;

public class PlayerRollAttack : RollDice
{
    public static PlayerRollAttack instance;
    private bool completeRollAttack;

    public bool CompleteRollAttack { get => completeRollAttack; set => completeRollAttack = value; }

    private void Awake()
    {
        PlayerRollAttack.instance = this;
    }

    public override IEnumerator BouncyDice()
    {
        yield return base.BouncyDice();
        completeRollAttack = true;
    }
}
