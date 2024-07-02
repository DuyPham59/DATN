using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : MonoBehaviour
{
    private int posItemDelete;
    private bool runOne;

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

        if (posItemDelete == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && !runOne)
        {
            runOne = true;
            Debug.Log("ThiefPlayer");
            StartCoroutine(ActiveText("PlayerThief"));
        }
        else if (posItemDelete == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && !runOne)
        {
            runOne = true;
            Debug.Log("ThiefEnemy");
            StartCoroutine(ActiveText("EnemyThief"));
        }
    }

    IEnumerator ActiveText(string thief)
    {
        if (thief == "PlayerThief")
        {
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn bị trộm mất một thẻ bài ngẫu nhiên";
            yield return new WaitForSeconds(2);
            if (CardInPlayerBag.instance.CardBag.Count != 0)
            {
                int random = Random.Range(0, CardInPlayerBag.instance.CardBag.Count);
                CardInPlayerBag.instance.CardBag[random].gameObject.SetActive(false);
                CardInPlayerBag.instance.CardBag.RemoveAt(random);
            }
            ManagerText.instance.textNotification.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (thief == "EnemyThief")
        {
            yield return new WaitForSeconds(2);
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
