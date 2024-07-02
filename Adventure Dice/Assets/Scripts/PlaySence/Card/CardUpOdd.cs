using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpOdd : MonoBehaviour
{
    private int[] odd = { 1, 3, 5 };
    [SerializeField] private Animator card;

    private void OnMouseDown()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0)
        {
            BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
            BtnRollToMove.instance.Roll.gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
            StartCoroutine(AniCard());
            int random = odd[Random.Range(0, odd.Length)];
        }
    }

    IEnumerator AniCard()
    {
        card.enabled = true;
        card.SetInteger("AniPlayer", 1);
        yield return new WaitForSeconds(1.5f);
        int random = odd[Random.Range(0, odd.Length)];
        CardManager.instance.NumberAndNameCard(random, "Up");
        MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
        Destroy(gameObject);
    }
}
