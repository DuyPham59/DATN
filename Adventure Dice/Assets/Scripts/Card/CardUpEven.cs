using UnityEngine;

public class CardUpEven : MonoBehaviour
{
    private int[] even = { 2, 4, 6 };

    private void OnMouseDown()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (Map.Instance.Grass[posPlayer].childCount == 0)
        {
            int random = even[Random.Range(0, even.Length)];
            CardManager.instance.NumberAndNameCard(random, "Up");
            MovingManager.instance.ActivePlayerMovingByName("PlayerMovingByCard");
            gameObject.SetActive(false);
            CardInPlayerBag.instance.CardBag.Remove(gameObject);
        }
    }
}
