using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpSmall : MonoBehaviour
{
    private int[] small = { 1, 2, 3 };

    private void OnMouseDown()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0)
        {
            int random = small[Random.Range(0, small.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
