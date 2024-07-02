using System.Collections.Generic;
using UnityEngine;

public class ItemTrap : MonoBehaviour
{
    private int posTrap;
    private bool playerCheckOne;
    private bool enemyCheckOne;
    private bool playerTrap;
    private bool enemyTrap;
    private bool playerRollOne;
    private bool enemyRollOne;
    private bool playerRunOne;
    private bool enemyRunOne;
    private int playerNumberDice;
    private int enemyNumberDice;
    private int[] listDiceNumberPlayerExit;
    private int[] listDiceNumberEnemyExit;
    private bool playerExit;
    private bool enemyExit;
    private Animator aniEnemy;
    private Animator aniPlayer;

    private void Awake()
    {
        playerCheckOne = true;
        enemyCheckOne = true;
        playerRollOne = true;
        enemyRollOne = true;
        playerNumberDice = 2;
        enemyNumberDice = 2;
        aniEnemy = GameObject.Find("Enemy").GetComponent<Animator>();
        aniPlayer = GameObject.Find("Player").GetComponent<Animator>();
        PosTrap();
    }

    private void Update()
    {
        CheckTrapPlayer();
        CheckTrapEnemy();
        PlayerRandomDice();
        EnemyRandomDice();
        PlayerExitTrap();
        EnemyExitTrap();
    }

    void PosTrap()
    {
        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            if (Map.Instance.Grass[i].name == transform.parent.name)
            {
                posTrap = i;
                break;
            }
        }
    }

    void PlayerExitTrap()
    {
        if (PlayerRollExitTrap.instance.CompleteRollExitTrap && playerRunOne)
        {
            playerRunOne = false;
            PlayerRollExitTrap.instance.CompleteRollExitTrap = false;
            
            for (int i = 0; i < listDiceNumberPlayerExit.Length; i++)
            {
                if (listDiceNumberPlayerExit[i] == PlayerRollExitTrap.instance.RandomDice)
                {
                    playerExit = true;
                    break;
                }
            }
            if (playerExit == true)
            {
                Debug.Log("PlayerExit");
                aniPlayer.SetTrigger("Idle");
                ManagerText.instance.textNotification.gameObject.SetActive(false);
                playerCheckOne = true;
                MovingManager.instance.ActivePlayerMovingByName("PlayerMovingExit");
                playerTrap = false;
                playerRollOne = true;
                playerNumberDice = 2;
                playerExit = false;
            }
            else
            {
                ManagerText.instance.textNotification.gameObject.SetActive(false);
                Debug.Log("PlayerExitFalse");
                playerNumberDice = playerNumberDice + 1;
                Turn.instance.PlayerTurn = false;
                playerRollOne = true;
            }
        }
    }

    void EnemyExitTrap()
    {
        if (EnemyRollExitTrap.instance.CompleteRollExitTrap && enemyRunOne)
        {
            enemyRunOne = false;
            EnemyRollExitTrap.instance.CompleteRollExitTrap = false;
           
            for (int i = 0; i < listDiceNumberEnemyExit.Length; i++)
            {
                if (listDiceNumberEnemyExit[i] == EnemyRollExitTrap.instance.RandomDice)
                {
                    enemyExit = true;
                    break;
                }
            }
            if (enemyExit == true)
            {
                Debug.Log("EnemyExit");
                enemyCheckOne = true;
                aniEnemy.SetTrigger("Idle");
                MovingManager.instance.ActiveEnemyMovingByName("EnemyMovingExit");
                enemyTrap = false;
                enemyRollOne = true;
                enemyNumberDice = 2;
                enemyExit = false;
            }
            else
            {
                Debug.Log("EnemyExitFalse");
                enemyNumberDice = enemyNumberDice + 1;
                Turn.instance.PlayerTurn = true;
                enemyRollOne = true;
            }
        }
    }

    void CheckTrapPlayer()
    {
        int posPlayer = PosPlayer.instance.pos;
        if (posTrap == posPlayer && !MovingManager.instance.SetActivePlayerMoving() && playerCheckOne && Turn.instance.PlayerTurn)
        {
            aniPlayer.SetTrigger("Trap");
            playerCheckOne = false;
            playerTrap = true;
            Turn.instance.PlayerTurn = false;
            Debug.Log("PlayerTRap");
        }
    }

    void CheckTrapEnemy()
    {
        int posEnemy = PosEnemy.instance.pos;
        if (posTrap == posEnemy && !MovingManager.instance.SetActiveEnemyMoving() && enemyCheckOne && !Turn.instance.PlayerTurn)
        {
            aniEnemy.SetTrigger("Trap");
            enemyCheckOne = false;
            enemyTrap = true;
            Turn.instance.PlayerTurn = true;
            Debug.Log("EnemyTrap");
        }
    }

    void PlayerRandomDice()
    {
        if (playerTrap && Turn.instance.PlayerTurn && playerRollOne)
        {
            playerRollOne = false;
            playerRunOne = true;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            listDiceNumberPlayerExit = new int[playerNumberDice];
            ManagerText.instance.textNotification.gameObject.SetActive(true);
            ManagerText.instance.textNotification.text = "Bạn phải đổ xúc xắc ra một trong số các số sau :";
            for (int i = 0; i < playerNumberDice; i++)
            {
                int diceExit = Random.Range(0, listNumberDice.Count);
                listDiceNumberPlayerExit[i] = listNumberDice[diceExit];
                listNumberDice.RemoveAt(diceExit);
                ManagerText.instance.textNotification.text = ManagerText.instance.textNotification.text + "  " + listDiceNumberEnemyExit[i];
            }
            BtnRollExitTrap.instance.Roll.gameObject.SetActive(true);
        }
    }

    void EnemyRandomDice()
    {
        if (enemyTrap && !Turn.instance.PlayerTurn && enemyRollOne)
        {
            enemyRollOne = false;
            enemyRunOne = true;
            List<int> listNumberDice = new List<int> { 1, 2, 3, 4, 5, 6 };
            listDiceNumberEnemyExit = new int[enemyNumberDice];
            
            for (int i = 0; i < enemyNumberDice; i++)
            {
                int diceExit = Random.Range(0, listNumberDice.Count);
                listDiceNumberEnemyExit[i] = listNumberDice[diceExit];
                listNumberDice.RemoveAt(diceExit);
                
            }
            StartCoroutine(EnemyRollExitTrap.instance.Roll());
        }
    }
}
