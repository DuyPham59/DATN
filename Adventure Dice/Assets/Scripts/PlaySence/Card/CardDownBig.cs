using System.Collections;
using UnityEngine;

public class CardDownBig : MonoBehaviour
{
    private int[] big = { 4, 5, 6 };
    [SerializeField] private Animator card;

    private void OnMouseDown()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0 && posEnemy != 0)
        {
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
        yield return new WaitForSeconds(1.5f);
        int random = big[Random.Range(0, big.Length)];
        CardManager.instance.NumberAndNameCard(random, "Down");
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
        Destroy(gameObject);
    }
}
