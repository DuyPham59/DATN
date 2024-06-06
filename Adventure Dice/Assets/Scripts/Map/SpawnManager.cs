using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject boss1Prefab;
    private Transform grassPos;
    private static SpawnManager instance;

    public static SpawnManager Instance => instance;

    private void Awake()
    {
        SpawnManager.instance = this;
    }
    private void Start()
    {
        for(int i = 1; i < 6; i++)
        {
            grassPos = Map.Instance.Grass[i];
            GameObject boss1 = Instantiate(boss1Prefab , grassPos.position , Quaternion.identity , grassPos);
            boss1.name = "Boss1";
        }
    }
}
