public class Boss1 : Boss
{
    protected override void Awake()
    {
        base.Awake();
        lengthArray = 4;
        arrayDiceDefeatBoss = new int[lengthArray];
    }


}
