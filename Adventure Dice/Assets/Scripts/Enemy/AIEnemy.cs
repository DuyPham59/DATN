using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    private bool chooseCard;
    private bool rollOne;
    public static AIEnemy instance;

    private void Awake()
    {
        AIEnemy.instance = this;
    }

    private void Update()
    {
        MoveByRoll();
    }

    private void MoveByRoll()
    {
        int pos = PosEnemy.instance.pos;
        bool turn = Turn.instance.PlayerTurn;
        bool setActiveEnemyMoving = MovingManager.instance.SetActiveEnemyMoving();
        bool setActivePlayerMoving = MovingManager.instance.SetActivePlayerMoving();
        if (!turn && Map.Instance.Grass[pos].childCount == 0 && !setActiveEnemyMoving && !setActivePlayerMoving)
        {
            if (CardInEnemyBag.instance.CardBag.Count == 0 && !rollOne)
            {
                EnemyRollToMove.instance.Roll();
                rollOne = true;
                return;
            }

            if (CardInEnemyBag.instance.CardBag.Count != 0)
            {
                for (int i = 0; i < CardInEnemyBag.instance.CardBag.Count; i++)
                {
                    ChooseCardInBag(CardInEnemyBag.instance.CardBag[i].name);
                    if (chooseCard)
                    {
                        CardInEnemyBag.instance.CardBag.RemoveAt(i);
                        chooseCard = false;
                        return;
                    }
                }
            }

            if (!chooseCard && !rollOne)
            {
                rollOne = true;
                EnemyRollToMove.instance.Roll();
                return;
            }

            Turn.instance.PlayerTurn = true;
            rollOne = false;
        }
    }

    public void ChooseCardInBag(string name)
    {
        switch (name)
        {
            case "CardUpBig":
                int[] bigUp = { 4, 5, 6 };
                CardUp(bigUp);
                break;
            case "CardUpEven":
                int[] evenUp = { 2, 4, 6 };
                CardUp(evenUp);
                break;
            case "CardUpOdd":
                int[] oddUp = { 1, 3, 5 };
                CardUp(oddUp);
                break;
            case "CardUpSmall":
                int[] smallUp = { 1, 2, 3 };
                CardUp(smallUp);
                break;
            case "CardDownBig":
                int[] bigDown = { 4, 5, 6 };
                CardDown(bigDown);
                break;
            case "CardDownEven":
                int[] evenDown = { 2, 4, 6 };
                CardDown(evenDown);
                break;
            case "CardDownOdd":
                int[] oddDown = { 1, 3, 5 };
                CardDown(oddDown);
                break;
            case "CardDownSmall":
                int[] smallDown = { 1, 2, 3 };
                CardDown(smallDown);
                break;
            default:
                break;
        }
    }

    void CardUp(int[] diceNumber)
    {
        int numberOption = 0;
        for (int i = 0; i < 3; i++)
        {
            if (ChildGrassNoHarmful(PosEnemy.instance.pos + diceNumber[i]))
            {
                numberOption += 1;
            }
        }
        if (numberOption >= 2)
        {
            int random = diceNumber[Random.Range(0, diceNumber.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            chooseCard = true;
        }
    }

    void CardDown(int[] diceNumber)
    {
        if (PosPlayer.instance.pos != 0 && Map.Instance.Grass[PosPlayer.instance.pos].childCount == 0)
        {
            int numberOption = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ChildGrassHarmful(PosPlayer.instance.pos - diceNumber[i]))
                {
                    numberOption += 1;
                }
            }
            if (numberOption >= 2)
            {
                int random = diceNumber[Random.Range(0, diceNumber.Length)];
                CardManager.instance.NumberAndNameCard(random, "Down");
                MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
                chooseCard = true;
            }
        }
    }

    bool ChildGrassNoHarmful(int i)
    {
        if (Map.Instance.Grass[i].childCount > 0)
        {
            if (i > (Map.Instance.Grass.Count - 1))
            {
                i = Map.Instance.Grass.Count - 1;
            }
            string name = Map.Instance.Grass[i].GetChild(0).gameObject.name;
            switch (name)
            {
                case "ItemChest":
                    return true;
                case "ArrowUp":
                    return true;
                default:
                    return false;
            }
        }
        return true;
    }

    bool ChildGrassHarmful(int i)
    {
        if (i < 0)
        {
            i = 0;
        }
        if (Map.Instance.Grass[i].childCount > 0)
        {
            string name = Map.Instance.Grass[i].GetChild(0).gameObject.name;
            switch (name)
            {
                case "Boss1":
                    return true;
                case "Boss2":
                    return true;
                case "Boss3":
                    return true;
                case "ArrowDown":
                    return true;
                case "ItemTrap":
                    return true;
                case "Thief":
                    return true;
                default:
                    return false;
            }
        }
        return true;
    }
}
