using UnityEngine;

public class CarDownSmall : MonoBehaviour
{
    private int[] small = { 1, 2, 3 };

    private void OnMouseDown()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (Map.Instance.Grass[posEnemy].childCount == 0)
        {
            int random = small[Random.Range(0, small.Length)];
            CardManager.instance.NumberAndNameCard(random, "Down");
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
