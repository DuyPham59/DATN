using UnityEngine;

public class CardDownBig : MonoBehaviour
{
    private int[] big = { 4, 5, 6 };

    private void OnMouseDown()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0)
        {
            int random = big[Random.Range(0, big.Length)];
            CardManager.instance.NumberAndNameCard(random, "Down");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
