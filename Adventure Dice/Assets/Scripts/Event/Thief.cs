using UnityEngine;

public class Thief : MonoBehaviour
{
    private int posItemDelete;

    private void Awake()
    {
        PosArrow();
    }

    private void Update()
    {
        CheckItemDelete();
    }

    void PosArrow()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posItemDelete = i;
                break;
            }
        }
    }

    void CheckItemDelete()
    {

        if (posItemDelete == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving())
        {
            Debug.Log("Run");
            if (CardInPlayerBag.instance.CardBag.Count != 0)
            {
                int random = Random.Range(0, CardInPlayerBag.instance.CardBag.Count);
                CardInPlayerBag.instance.CardBag[random].gameObject.SetActive(false);
                CardInPlayerBag.instance.CardBag.RemoveAt(random);
            }
            Destroy(gameObject);
        }
        else if (posItemDelete == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving())
        {
            Debug.Log("Run");
            if (CardInEnemyBag.instance.CardBag.Count != 0)
            {
                int random = Random.Range(0, CardInEnemyBag.instance.CardBag.Count);
                CardInEnemyBag.instance.CardBag[random].gameObject.SetActive(false);
                CardInEnemyBag.instance.CardBag.RemoveAt(random);
            }
            Destroy(gameObject);
        }
    }
}
