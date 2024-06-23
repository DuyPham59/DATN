using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpOdd : MonoBehaviour
{
    private int[] odd = { 1, 3, 5 };

    private void OnMouseDown()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0)
        {
            int random = odd[Random.Range(0, odd.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
