using System.Collections;
using UnityEngine;

public class ArrowUp : MonoBehaviour
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
        if (Turn.instance.PlayerTurn && posArrow == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && runOne)
        {
            Debug.Log("PlayerArrowUp");
            runOne = false;
            StartCoroutine(ActiveText("PlayerMoveUp"));
        }
        else if (!Turn.instance.PlayerTurn && posArrow == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && runOne)
        {
            Debug.Log("EnemyArrowUp");
            runOne = false;
            StartCoroutine(ActiveText("EnemyMoveUp"));
        }
    }

    IEnumerator ActiveText(string moveDown)
    {
        if (moveDown == "PlayerMoveUp")
        {
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn tiến lên ngẫu nhiên";
            yield return new WaitForSeconds(2);
            MovingManager.instance.ActivePlayerMovingByName("PlayerMoveUpRandom");
            ManagerText.instance.textNotification.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (moveDown == "EnemyMoveUp")
        {
            yield return new WaitForSeconds(2);
            MovingManager.instance.ActiveEnemyMovingByName("EnemyMoveUpRandom");
            Destroy(gameObject);
        }
    }
}
