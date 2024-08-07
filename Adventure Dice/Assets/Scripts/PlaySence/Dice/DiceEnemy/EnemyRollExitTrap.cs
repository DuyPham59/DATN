using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRollExitTrap : MonoBehaviour
{
    public static EnemyRollExitTrap instance;
    private int randomDice;
    private bool completeRollExitTrap;

    public bool CompleteRollExitTrap { get => completeRollExitTrap; set => completeRollExitTrap = value; }
    public int RandomDice => randomDice;

    private void Awake()
    {
        EnemyRollExitTrap.instance = this;
    }

    public IEnumerator Roll()
    {
        yield return new WaitForSeconds(5);
        randomDice = Random.Range(1, 7);
        completeRollExitTrap = true;
    }
}
