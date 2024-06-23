using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpBig : MonoBehaviour
{
    private int[] big = { 4, 5, 6 };

    private void OnMouseDown()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0)
        {
            int random = big[Random.Range(0, big.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
