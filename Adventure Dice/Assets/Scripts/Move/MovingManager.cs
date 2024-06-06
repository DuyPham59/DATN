using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerMovingArray;
    [SerializeField] private List<GameObject> enemyMovingArray;
    public static MovingManager instance;

    private void Awake()
    {
        MovingManager.instance = this;
    }

    public bool SetActivePlayerMoving()
    {
        for (int i = 0; i < playerMovingArray.Count; i++)
        {
            if (playerMovingArray[i].activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void ActivePlayerMovingByName(string name)
    {
        for (int i = 0; i < playerMovingArray.Count; i++)
        {
            if (playerMovingArray[i].name == name)
            {
                playerMovingArray[i].SetActive(true);
                return;
            }
        }
    }

    public bool SetActiveEnemyMoving()
    {
        for (int i = 0; i < enemyMovingArray.Count; i++)
        {
            if (enemyMovingArray[i].activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void ActiveEnemyMovingByName(string name)
    {
        for (int i = 0; i < enemyMovingArray.Count; i++)
        {
            if (enemyMovingArray[i].name == name)
            {
                enemyMovingArray[i].SetActive(true);
                return;
            }
        }
    }
}
