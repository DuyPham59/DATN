using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMove : MonoBehaviour
{
    private int posDoubleMove;
    private bool runOne;

    private void Awake()
    {
        PosDoubleMove();
    }

    private void Update()
    {
        CheckDoubleMove();
    }

    void PosDoubleMove()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posDoubleMove = i;
                break;
            }
        }
    }

    void CheckDoubleMove()
    {
        if (Turn.instance.PlayerTurn && posDoubleMove == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && !runOne)
        {
            runOne = true;
            Debug.Log("PlayrMOveDouble");
            StartCoroutine(ActiveText("PlayerDoubleMove"));
            
        }
        else if (!Turn.instance.PlayerTurn && posDoubleMove == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && !runOne)
        {
            runOne = true;
            Debug.Log("ENemyMoveDOuble");
            StartCoroutine(ActiveText("EnemyDoubleMove"));
        }
    }

    IEnumerator ActiveText(string doubleMove)
    {
        if (doubleMove == "PlayerDoubleMove")
        {
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Lượt đổ xúc xắc di chuyển tiếp theo của bạn được nhân đôi";
            yield return new WaitForSeconds(2);
            PlayerRollToMove.instance.doubleMove = true;
            ManagerText.instance.textNotification.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (doubleMove == "EnemyDoubleMove")
        {
            yield return new WaitForSeconds(2);
            EnemyRollToMove.instance.doubleMove = true;
            Destroy(gameObject);
        }
    }
}
