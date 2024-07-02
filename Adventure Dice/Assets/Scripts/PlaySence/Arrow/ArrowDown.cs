using System.Collections;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    private int posArrow;
    private bool runOne;

    private void Awake()
    {
        runOne = true;
        PosArrow();
    }

    private void Update()
    {
        CheckArrow();
    }

    void PosArrow()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posArrow = i;
                break;
            }
        }
    }

    void CheckArrow()
    {
        if (posArrow == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && runOne)
        {
            Debug.Log("PlayerArrowDown");
            runOne = false;
            StartCoroutine(ActiveText("PlayerMoveDown"));
        }
        else if (posArrow == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && runOne)
        {
            Debug.Log("EnemyArrowDown");
            runOne = false;
            StartCoroutine(ActiveText("EnemyMoveDown"));
        }
    }

    IEnumerator ActiveText(string moveDown)
    {
        if (moveDown == "PlayerMoveDown")
        {
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn bị đi lùi ngẫu nhiên";
            yield return new WaitForSeconds(2);
            MovingManager.instance.ActivePlayerMovingByName("PlayerMoveDownRandom");
            ManagerText.instance.textNotification.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (moveDown == "EnemyMoveDown") {
            yield return new WaitForSeconds(2);
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMoveDownRandom");
            Destroy(gameObject);
        }
    }
}
