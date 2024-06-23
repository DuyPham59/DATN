using System.Collections.Generic;
using UnityEngine;

public class CardInPlayerBag : MonoBehaviour
{
    public static CardInPlayerBag instance;
    [SerializeField] private Vector3 posCard;
    [SerializeField][Range(0f, 10f)] private float variable;
    [SerializeField] private List<GameObject> cardBag;

    public List<GameObject> CardBag { get => cardBag; set => cardBag = value; }

    private void Awake()
    {
        CardInPlayerBag.instance = this;
    }

    private void Update()
    {
        PosCards();
    }

    public void AddMyCard(GameObject card)
    {
        if (cardBag.Count == 3)
        {
            Debug.Log("Tui player da day");
        }

        else
        {
            GameObject addCard = Instantiate(card);
            cardBag.Add(addCard);
            cardBag[cardBag.Count - 1].transform.position = posCard + new Vector3((cardBag.Count - 1) * variable, 0, 0);
        }
    }

    private void PosCards()
    {
        for (int i = 0; i < cardBag.Count; i++)
        {
            cardBag[i].transform.position = posCard + new Vector3(i * variable, 0, 0);
        }
    }
}
