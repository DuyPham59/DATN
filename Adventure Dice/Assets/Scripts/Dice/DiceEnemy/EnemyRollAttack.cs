using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollAttack : MonoBehaviour
{
    public static EnemyRollAttack instance;
    private int randomDice;
    private bool completeRollAttack;

    public bool CompleteRollAttack { get => completeRollAttack; set => completeRollAttack = value; }
    public int RandomDice  => randomDice;

    private void Awake()
    {
        EnemyRollAttack.instance = this;
    }

    public void Roll()
    {
        randomDice = Random.Range(1, 7);
        completeRollAttack = true;
    }
}
