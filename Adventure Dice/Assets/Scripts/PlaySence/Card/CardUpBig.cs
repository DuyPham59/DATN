using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpBig : MonoBehaviour
{
    private int[] big = { 4, 5, 6 };
    [SerializeField] private Animator card;

    private void OnMouseDown()
    {
        bool turnPlayer = Turn.instance.PlayerTurn;
        bool state = CardManager.instance.statePlayerUseCard;
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0 && !state && turnPlayer && !MovingManager.instance.SetActiveEnemyMoving() && !MovingManager.instance.SetActivePlayerMoving() && PlayerRollToMove.instance.completeRoll)
        {
            CardManager.instance.statePlayerUseCard = true;
            BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
            BtnRollToMove.instance.Roll.gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
            StartCoroutine(AniCard());
        }
    }

    IEnumerator AniCard()
    {
        card.enabled = true;
        card.SetInteger("AniPlayer", 1);
        yield return new WaitForSeconds(2f);
        int random = big[Random.Range(0, big.Length)];
        CardManager.instance.NumberAndNameCard(random, "Up");
        MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
        CardManager.instance.statePlayerUseCard = false;
        Destroy(gameObject);
    }
}
