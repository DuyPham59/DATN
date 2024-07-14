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
    private Animator aniEnemy;
    private Animator aniPlayer;

    protected virtual void Awake()
    {
        aniEnemy = GameObject.Find("Enemy").GetComponent<Animator>();
        aniPlayer = GameObject.Find("Player").GetComponent<Animator>();
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
                aniPlayer.SetTrigger("Idle");
                aniPlayer.SetTrigger("Attack");
                ManagerText.instance.textNotification.gameObject.SetActive(false);
                Destroy(gameObject);
                CardManager.instance.addCard("Player");
            }
            else
            {
                aniPlayer.SetTrigger("Idle");
                ManagerText.instance.textNotification.gameObject.SetActive(false);
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
                aniEnemy.SetTrigger("Idle");
                aniEnemy.SetTrigger("Attack");
                Destroy(gameObject);
                CardManager.instance.addCard("Enemy");
            }
            else
            {
                aniEnemy.SetTrigger("Idle");
                MovingManager.instance.ActiveEnemyMovingByName("EnemyMoveDownRandom");
                checkOnce = true;
            }
        }
    }
    protected void CheckBossAttack()
    {
        if (posBoss == PosPlayer.instance.pos && !MovingManager.instance.SetActivePlayerMoving() && checkOnce && Turn.instance.PlayerTurn)
        {
            Debug.Log("BossAttackPlayer");
            checkOnce = false;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            aniPlayer.SetTrigger("Defensive");
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn phải đổ xúc xắc ra một trong số các số sau :";
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, listNumberDice.Count);
                arrayDiceDefeatBoss[i] = listNumberDice[diceDefeatBoss1];
                listNumberDice.RemoveAt(diceDefeatBoss1);
                ManagerText.instance.textNotification.text = ManagerText.instance.textNotification.text + "  " + arrayDiceDefeatBoss[i];
            }
            boss1AttackPlayer = true;
            BtnRollAttack.instance.Roll.gameObject.SetActive(true);
        }
        else if (posBoss == PosEnemy.instance.pos && !MovingManager.instance.SetActiveEnemyMoving() && checkOnce && !Turn.instance.PlayerTurn)
        {
            Debug.Log("BossAttackEnemy");
            checkOnce = false;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            aniEnemy.SetTrigger("Defensive");
            for (int i = 0; i < arrayDiceDefeatBoss.Length; i++)
            {
                int diceDefeatBoss1 = Random.Range(0, listNumberDice.Count);
                arrayDiceDefeatBoss[i] = listNumberDice[diceDefeatBoss1];
                listNumberDice.RemoveAt(diceDefeatBoss1);
            }
            boss1AttackEnemy = true;
            StartCoroutine( EnemyRollAttack.instance.Roll());
        }
    }
}
