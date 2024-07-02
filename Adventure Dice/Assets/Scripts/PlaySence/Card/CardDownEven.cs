using System.Collections;
using UnityEngine;

public class CardDownEven : MonoBehaviour
{
    private int[] even = { 2, 4, 6 };
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
        int random = even[Random.Range(0, even.Length)];
        CardManager.instance.NumberAndNameCard(random, "Down");
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
        Destroy(gameObject);
    }
}
