using System.Collections;
using UnityEngine;

public class CarDownSmall : MonoBehaviour
{
    private int[] small = { 1, 2, 3 };
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
        int random = small[Random.Range(0, small.Length)];
        CardManager.instance.NumberAndNameCard(random, "Down");
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
        Destroy(gameObject);
    }
}
