using UnityEngine;

public class CardInPlayerBag : MonoBehaviour
{
    private GameObject[] cardBag;

    private void Awake()
    {
        cardBag = new GameObject[5];
    }

    private void Update()
    {
        for (int i = 0; i < cardBag.Length; i++)
        {
            if (cardBag[i] == null)
            {
                cardBag[i] = CardManager.instance.Card;
            }
        }
    }
}
