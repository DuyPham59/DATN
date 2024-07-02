using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInEnemyBag : MonoBehaviour
{
    public static CardInEnemyBag instance;
    [SerializeField] private List<GameObject> cardBag;

    public List<GameObject> CardBag { get => cardBag; set => cardBag = value; }

    private void Awake()
    {
        CardInEnemyBag.instance = this;
    }

    public void AddMyCard(GameObject card)
    {
        if (cardBag.Count == 3)
        {
            Debug.Log("Tui Enemy da day");
        }

        else
        {
            cardBag.Add(card);
        }
    }
}
