using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRollToMove : MonoBehaviour
{
    public static EnemyRollToMove instance;
    public bool doubleMove;
    private int randomDice;
    private bool completeRoll;

    public int RandomDice => randomDice;

    public bool CompleteRoll { get => completeRoll; set => completeRoll = value; }

    private void Awake()
    {
        EnemyRollToMove.instance = this;
    }

    public IEnumerator Roll()
    {
        yield return new WaitForSeconds(5);
        randomDice = Random.Range(1, 7);
        if (doubleMove)
        {
            doubleMove = false;
            randomDice *= 2;
        }
        completeRoll = true;
        MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingByRoll");
    }
}
