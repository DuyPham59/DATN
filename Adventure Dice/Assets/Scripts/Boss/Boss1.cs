using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private bool checkOnce;
    private int[] arrayDiceDefeatBoss1;
    private bool boss1AttackPlayer;
    private bool boss1AttackEnemy;
    private bool collisionPlayer;
    private bool collisionEnemy;
    private bool killBoss;


    //public bool Boss1AttackPlayer => boss1AttackPlayer;
    //public bool Boss1AttackEnemy => boss1AttackEnemy;

    //public bool CollisionPlayer => collisionPlayer;

    //public bool CollisionEnemy => collisionEnemy;

    private void Awake()
    {
        checkOnce = true;
        arrayDiceDefeatBoss1 = new int[4];
    }

    private void Update()
    {
        CheckBossAttack();
        PlayerKillBoss();
        EnemyKillBoss();
    }

    void PlayerKillBoss()
    {
        if (boss1AttackPlayer /*&& PlayerRollToMove.instance.CompleteRoll*/)
        {
            boss1AttackPlayer = false;
            for (int i = 0; i < 4; i++)
            {
                Debug.Log(arrayDiceDefeatBoss1[i]);
                if (arrayDiceDefeatBoss1[i] == PlayerRollToMove.instance.RandomDice)
                {
                    killBoss = true;
                }
            }
            if (killBoss == true)
            {
                Debug.Log("win");
                Instantiate(CardManager.instance.cardList[Random.Range(0, 8)], new Vector3(0, -4, 0), Quaternion.identity);
                Turn.instance.PlayerTurn = false;
            }
            else
            {

            }
        }
    }

    void EnemyKillBoss()
    {
        if (boss1AttackEnemy)
        {
            boss1AttackEnemy = false;
            int diceNumber = Random.Range(1, 7);
            for (int i = 0; i < 4; i++)
            {
                if (arrayDiceDefeatBoss1[i] == diceNumber)
                {
                    killBoss = true;
                    break;
                }
            }
            if (killBoss == true)
            {
                Turn.instance.PlayerTurn = true;
                BtnRollToMove.instance.Roll.gameObject.SetActive(true);
            }
            else
            {
                //EnemyMoving.instance.EnemyDown = true;
                //EnemyMoving.instance.EnemyIsMoving = true;
            }
        }
    }
    void CheckBossAttack()
    {
        if ( /*&& */!MovingManager.instance.SetActivePlayerMoving() && checkOnce)
        {
            checkOnce = false;
            List<int> arrayNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < 4; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, arrayNumberDice.Count);
                arrayDiceDefeatBoss1[i] = arrayNumberDice[diceDefeatBoss1];
                arrayNumberDice.RemoveAt(diceDefeatBoss1);
            }
            boss1AttackPlayer = true;
            BtnRollToMove.instance.Roll.gameObject.SetActive(true);
        }
        else if (collisionEnemy /*&& EnemyMoving.instance.FinishMoving*/ && checkOnce)
        {
            checkOnce = false;
            List<int> arrayNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < 4; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, arrayNumberDice.Count);
                arrayDiceDefeatBoss1[i] = arrayNumberDice[diceDefeatBoss1];
                arrayNumberDice.RemoveAt(diceDefeatBoss1);
            }
            boss1AttackEnemy = true;
        }
    }
}
