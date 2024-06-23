using UnityEngine;

public class CardDownEven : MonoBehaviour
{
    private int[] even = { 2, 4, 6 };

    private void OnMouseDown()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0)
        {
            int random = even[Random.Range(0, even.Length)];
            CardManager.instance.NumberAndNameCard(random, "Down");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
