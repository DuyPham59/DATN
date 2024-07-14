using System.Collections;
using UnityEngine;

public class CardDownOdd : MonoBehaviour
{
    private int[] odd = { 1, 3, 5 };
    [SerializeField] private Animator card;

    private void OnMouseDown()
    {
        bool turnPlayer = Turn.instance.PlayerTurn;
        bool state = CardManager.instance.statePlayerUseCard;
        int posPlayer = PosPlayer.instance.pos;
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0 && Map.Instance.Grass[posPlayer].childCount == 0
            && posEnemy != 0 && !state && turnPlayer && !MovingManager.instance.SetActiveEnemyMoving()
            && !MovingManager.instance.SetActivePlayerMoving() && PlayerRollToMove.instance.completeRoll)
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
        int random = odd[Random.Range(0, odd.Length)];
        CardManager.instance.NumberAndNameCard(random, "Down");
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
        CardManager.instance.statePlayerUseCard = false;
        Destroy(gameObject);
    }
}
