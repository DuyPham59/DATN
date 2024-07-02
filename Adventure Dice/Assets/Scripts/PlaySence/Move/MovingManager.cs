using System.Collections.Generic;
using UnityEngine;

public class MovingManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerMovingArray;
    [SerializeField] private List<GameObject> enemyMovingArray;
    private float updateTimePlayerActive;
    private float updateTimeEnemyActive;
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

        if (!SetActivePlayerMoving() /*&& (UnityEngine.Time.time - updateTimePlayerActive) > 1.5*/)
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
    }

    ////public bool FindPlayerMovingByName(string name)
    //{
    //    for (int i = 0; i < playerMovingArray.Count; i++)
    //    {
    //        if (playerMovingArray[i].name == name)
    //        {
    //            if(playerMovingArray[i].activeSelf) return true;
    //            else return false;
    //        }
    //    }
    //    return false;
    //}

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
        if (!SetActiveEnemyMoving() /*&& (UnityEngine.Time.time - updateTimeEnemyActive) > 1.5*/)
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

    //public bool FindEnemyMovingByName(string name)
    //{
    //    for (int i = 0; i < enemyMovingArray.Count; i++)
    //    {
    //        if (enemyMovingArray[i].name == name)
    //        {
    //            if (enemyMovingArray[i].activeSelf) return true;
    //            else return false;
    //        }
    //    }
    //    return false;
    //}
}
