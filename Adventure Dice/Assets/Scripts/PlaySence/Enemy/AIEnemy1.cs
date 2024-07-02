using UnityEngine;

public class AIEnemy1 : MonoBehaviour
{
    private bool rollOne;

    private void Update()
    {
        MoveByRoll();
    }

    private void MoveByRoll()
    {
        int pos = PosEnemy.instance.pos;
        bool turn = Turn.instance.PlayerTurn;
        bool setActiveEnemyMoving = MovingManager.instance.SetActiveEnemyMoving();
        bool setActivePlayerMoving = MovingManager.instance.SetActivePlayerMoving();
        if (!turn && Map.Instance.Grass[pos].childCount == 0 && !setActiveEnemyMoving && !setActivePlayerMoving)
        {
            if (!rollOne)
            {
                rollOne = true;
                StartCoroutine(EnemyRollToMove.instance.Roll());
                return;
            }
            if (EnemyRollToMove.instance.CompleteRoll)
            {
                EnemyRollToMove.instance.CompleteRoll = false;
                Turn.instance.PlayerTurn = true;
                rollOne = false;
            }         
        }
    }
}
