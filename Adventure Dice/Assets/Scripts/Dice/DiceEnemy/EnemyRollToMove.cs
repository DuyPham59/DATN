using UnityEngine;
using UnityEngine.UI;

public class EnemyRollToMove : MonoBehaviour
{
    public static EnemyRollToMove instance;
    public bool doubleMove;
    private int randomDice;

    public int RandomDice => randomDice;

    private void Awake()
    {
        EnemyRollToMove.instance = this;
    }

    public void Roll()
    {
        randomDice = Random.Range(1, 7);
        if (doubleMove)
        {
            doubleMove = false;
            randomDice *= 2;
        }
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByRoll");
    }
}
