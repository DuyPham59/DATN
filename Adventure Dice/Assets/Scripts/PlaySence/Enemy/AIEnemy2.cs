using System.Collections;
using UnityEngine;

public class AIEnemy2 : MonoBehaviour
{
    private bool chooseCard;
    private bool rollOne;
    private bool runOne;
    public static AIEnemy2 instance;

    private void Awake()
    {
        //AIEnemy.instance = this;
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
                StartCoroutine(EnemyRollToMove.instance.Roll());
                rollOne = true;
                return;
            }

            if (CardInEnemyBag.instance.CardBag.Count != 0 )
            {
                if(rollOne && EnemyRollToMove.instance.CompleteRoll) {
                    for (int i = 0; i < CardInEnemyBag.instance.CardBag.Count; i++)
                    {
                        CardInBag(CardInEnemyBag.instance.CardBag[i].name, CardInEnemyBag.instance.CardBag[i]);
                        if (chooseCard)
                        {
                            chooseCard = false;
                            return;
                        }
                    }

                }

                else if(!rollOne)
                {
                    for (int i = 0; i < CardInEnemyBag.instance.CardBag.Count; i++)
                    {
                        CardInBag(CardInEnemyBag.instance.CardBag[i].name, CardInEnemyBag.instance.CardBag[i]);
                        if (chooseCard)
                        {
                            chooseCard = false;
                            return;
                        }
                    }
                }
            }

            if (!chooseCard && !rollOne)
            {
                rollOne = true;
                StartCoroutine( EnemyRollToMove.instance.Roll());
                return;
            }

            if (EnemyRollToMove.instance.CompleteRoll)
            {
                EnemyRollToMove.instance.CompleteRoll = false;
                Turn.instance.PlayerTurn = true;
                rollOne = false;
            }            
        }
    }

    public void CardInBag(string name, GameObject card)
    {
        switch (name)
        {
            case "CardUpBig":
                int[] bigUp = { 4, 5, 6 };
                CardUp(bigUp, card);
                break;
            case "CardUpEven":
                int[] evenUp = { 2, 4, 6 };
                CardUp(evenUp, card);
                break;
            case "CardUpOdd":
                int[] oddUp = { 1, 3, 5 };
                CardUp(oddUp, card);
                break;
            case "CardUpSmall":
                int[] smallUp = { 1, 2, 3 };
                CardUp(smallUp, card);
                break;
            case "CardDownBig":
                int[] bigDown = { 4, 5, 6 };
                CardDown(bigDown, card);
                break;
            case "CardDownEven":
                int[] evenDown = { 2, 4, 6 };
                CardDown(evenDown, card);
                break;
            case "CardDownOdd":
                int[] oddDown = { 1, 3, 5 };
                CardDown(oddDown, card);
                break;
            case "CardDownSmall":
                int[] smallDown = { 1, 2, 3 };
                CardDown(smallDown, card);
                break;
            default:
                break;
        }
    }

    void CardUp(int[] diceNumber, GameObject card)
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
            StartCoroutine(ChooseCardUp(diceNumber, card));
            chooseCard = true;
        }
    }

    void CardDown(int[] diceNumber, GameObject card)
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
                StartCoroutine(ChooseCardDown(diceNumber, card));
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
                case "DoubleMove":
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

    IEnumerator ChooseCardUp(int[] diceNumber, GameObject card)
    {
        if (!runOne)
        {
            runOne = true;
            yield return new WaitForSeconds(1.5f);
            GameObject cardObject = Instantiate(card, new Vector3(0, 3.96f, 0), Quaternion.identity);
            cardObject.GetComponent<Animator>().enabled = true;
            cardObject.GetComponent<Animator>().SetInteger("AniPlayer", 0);
            yield return new WaitForSeconds(2f);
            Debug.Log("RunUp");
            CardInEnemyBag.instance.CardBag.Remove(card);
            Destroy(cardObject);
            int random = diceNumber[Random.Range(0, diceNumber.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            runOne = false;
        }
    }

    IEnumerator ChooseCardDown(int[] diceNumber, GameObject card)
    {
        if (!runOne)
        {
            runOne = true;
            yield return new WaitForSeconds(1.5f);
            GameObject cardObject = Instantiate(card, new Vector3(0, 3.96f, 0), Quaternion.identity);
            cardObject.GetComponent<Animator>().enabled = true;
            cardObject.GetComponent<Animator>().SetInteger("AniPlayer", 0);
            yield return new WaitForSeconds(2f);
            Debug.Log("runDown");
            CardInEnemyBag.instance.CardBag.Remove(card);
            Destroy(cardObject);
            int random = diceNumber[Random.Range(0, diceNumber.Length)];
            CardManager.instance.NumberAndNameCard(random, "Down");
            MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
            runOne = false;
        }
    }
}
