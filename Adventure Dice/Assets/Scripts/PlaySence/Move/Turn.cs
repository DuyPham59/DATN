using System.Collections;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private bool playerTurn;
    private bool playerRunOne;
    private bool enemyRunOne;
    [SerializeField] GameObject enemyThink;
    [SerializeField] GameObject playerThink;
    public static Turn instance;
    public bool PlayerTurn { get => playerTurn; set => playerTurn = value; }

    private void Awake()
    {
        Turn.instance = this;
    }
    private void Start()
    {
        int randomTurn = Random.Range(0, 2);
        if (randomTurn == 0)
        {
            playerTurn = false;
        }
        else
        {
            playerTurn = true;
        }
    }

    private void Update()
    {
        StartCoroutine(TextTurn());
        aniThink();
    }

    IEnumerator TextTurn()
    {
        if (playerTurn && !playerRunOne)
        {
            playerRunOne = true;
            enemyRunOne = false;
            ManagerText.instance.textTurn.gameObject.SetActive(true);
            ManagerText.instance.textTurn.text = "Lượt của bạn";
            yield return new WaitForSeconds(5);
            ManagerText.instance.textTurn.gameObject.SetActive(false);
        }
        else if (!playerTurn && !enemyRunOne)
        {
            enemyRunOne = true;
            playerRunOne = false;
            ManagerText.instance.textTurn.gameObject.SetActive(true);
            ManagerText.instance.textTurn.text = "Lượt của đối thủ";
            yield return new WaitForSeconds(5);
            ManagerText.instance.textTurn.gameObject.SetActive(false);
        }  
    }

    void aniThink()
    {
        if (PlayerTurn && !MovingManager.instance.SetActivePlayerMoving())
        {
            playerThink.SetActive(true);
        }
        else
        {
            playerThink.SetActive(false);
        }

        if (!PlayerTurn && !MovingManager.instance.SetActiveEnemyMoving())
        {
            enemyThink.SetActive(true);
        }
        else
        {
            enemyThink.SetActive(false);
        }
    }
}
