using UnityEngine;

public class CardDownOdd : MonoBehaviour
{
    private int[] odd = { 1, 3, 5 };

    private void OnMouseDown()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0)
        {
            int random = odd[Random.Range(0, odd.Length)];
            CardManager.instance.NumberAndNameCard(random, "Down");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
