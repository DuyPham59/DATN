using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    protected int posBoss;
    protected bool checkOnce;
    protected int[] arrayDiceDefeatBoss;
    protected int lengthArray;
    protected bool boss1AttackPlayer;
    protected bool boss1AttackEnemy;
    protected bool killBoss;

    protected virtual void Awake()
    {
        PosBoss();
        checkOnce = true;
    }

    protected void Update()
    {
        CheckBossAttack();
        PlayerKillBoss();
        EnemyKillBoss();
    }

    protected void PosBoss()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {

                posBoss = i;
            }
        }
    }

    protected void PlayerKillBoss()
    {
        if (boss1AttackPlayer && PlayerRollAttack.instance.CompleteRollAttack)
        {
            boss1AttackPlayer = false;
            PlayerRollAttack.instance.CompleteRollAttack = false;
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                if (arrayDiceDefeatBoss[i] == PlayerRollAttack.instance.RandomDice)
                {
                    killBoss = true;
                    break;
                }
            }
            if (killBoss == true)
            {
                Destroy(gameObject);
                CardManager.instance.addCard("Player");
            }
            else
            {
                MovingManager.instance.ActivePlayerMovingByName("PlayerMoveDownRandom");
                checkOnce = true;
            }
        }
    }

    protected void EnemyKillBoss()
    {
        if (boss1AttackEnemy && EnemyRollAttack.instance.CompleteRollAttack)
        {
            boss1AttackEnemy = false;
            EnemyRollAttack.instance.CompleteRollAttack = false;
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                if (arrayDiceDefeatBoss[i] == EnemyRollAttack.instance.RandomDice)
                {
                    killBoss = true;
                    break;
                }
            }
            if (killBoss == true)
            {
                Destroy(gameObject);
                CardManager.instance.addCard("Enemy");
            }
            else
            {
                MovingManager.instance.ActiveEnemyMovingByName("EnemyMoveDownRandom");
                checkOnce = true;
            }
        }
    }
    protected void CheckBossAttack()
    {
        if (posBoss == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && checkOnce && Turn.instance.PlayerTurn)
        {
            checkOnce = false;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, listNumberDice.Count);
                arrayDiceDefeatBoss[i] = listNumberDice[diceDefeatBoss1];
                listNumberDice.RemoveAt(diceDefeatBoss1);
                Debug.Log("Run");
            }
            boss1AttackPlayer = true;
            BtnRollAttack.instance.Roll.gameObject.SetActive(true);
        }
        else if (posBoss == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && checkOnce && !Turn.instance.PlayerTurn)
        {
            checkOnce = false;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, listNumberDice.Count);
                arrayDiceDefeatBoss[i] = listNumberDice[diceDefeatBoss1];
                listNumberDice.RemoveAt(diceDefeatBoss1);
                Debug.Log(arrayDiceDefeatBoss[i]);
            }
            boss1AttackEnemy = true;
            EnemyRollAttack.instance.Roll();
        }
    }
}
