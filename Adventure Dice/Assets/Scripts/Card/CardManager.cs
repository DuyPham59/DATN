using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> listCard;
    private int numberCard;
    private string nameCard;
    private GameObject card;
    public static CardManager instance;

    public int NumberCard  => numberCard;
    public string NameCard  => nameCard;

    private void Awake()
    {
        CardManager.instance = this;
    }

    public void addCard(string name)
    {
        card = listCard[Random.Range(0, listCard.Count)];
        if(name == "Player")
        {
            CardInPlayerBag.instance.AddMyCard(card);
        }
        else if (name == "Enemy")
        {
            CardInEnemyBag.instance.AddMyCard(card);
        }
    }

    public void NumberAndNameCard(int i , string name)
    {
        numberCard = i;
        nameCard = name;
    }
}
