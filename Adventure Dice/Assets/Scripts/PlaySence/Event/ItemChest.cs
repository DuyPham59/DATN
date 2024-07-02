using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    private int posItemChest;
    private bool runOne;

    private void Awake()
    {
        PosArrow();
    }

    private void Update()
    {
        CheckItemChest();
    }

    void PosArrow()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posItemChest = i;
                break;
            }
        }
    }

    void CheckItemChest()
    {

        if (posItemChest == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && !runOne)
        {
            runOne = true;
            StartCoroutine(ActiveText("PlayerChest"));
            Debug.Log("AddCardplayer");
        }
        else if (posItemChest == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && !runOne)
        {
            runOne = true;
            StartCoroutine(ActiveText("EnemyChest"));
            Debug.Log("Add card enemy");
        }
    }

    IEnumerator ActiveText(string chest)
    {
        if (chest == "PlayerChest")
        {
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn nhận được một thẻ bài";
            yield return new WaitForSeconds(2);
            CardManager.instance.addCard("Player");
            ManagerText.instance.textNotification.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (chest == "EnemyChest")
        {
            yield return new WaitForSeconds(2);
            CardManager.instance.addCard("Enemy");
            Destroy(gameObject);
        }
    }
}
