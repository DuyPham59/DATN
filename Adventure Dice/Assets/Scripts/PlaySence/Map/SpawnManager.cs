using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsStart;
    [SerializeField] private GameObject win;
    [SerializeField] private List<int> ratiosStart;
    [SerializeField] private List<GameObject> respawns;
    [SerializeField] private List<int> ratioRespawns;
    private int totalRatio;

    private Transform grassPos;
    private static SpawnManager instance;

    public static SpawnManager Instance => instance;

    private void Awake()
    {
        SpawnManager.instance = this;
    }

    private void Start()
    {
        totalRatio = 0;
        foreach (var ratio in ratiosStart)
        {
            totalRatio += ratio;
        }

        for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
        {
            grassPos = Map.Instance.Grass[i];
            RandomPrefabs(grassPos, prefabsStart, ratiosStart);
        }
        grassPos = Map.Instance.Grass[Map.Instance.Grass.Count - 1];
        GameObject item = Instantiate(win, grassPos.position, Quaternion.identity, grassPos);
        item.name = item.name.Replace("(Clone)", "").Trim();

        totalRatio = 0;
        foreach (var ratio in ratioRespawns)
        {
            totalRatio += ratio;
        }
    }

    private void Update()
    {
        SpawnObject();
    }

    private void RandomPrefabs(Transform grassPos , List<GameObject> prefabs , List<int> ratios)
    {
        int randomValue = Random.Range(0, totalRatio);
        int cumulative = 0;

        for (int i = 0; i < prefabs.Count; i++)
        {
            cumulative += ratios[i];
            if (randomValue < cumulative)
            {
                if (prefabs[i] == null) break;
                GameObject item = Instantiate(prefabs[i], grassPos.position, Quaternion.identity, grassPos);

                item.name = item.name.Replace("(Clone)", "").Trim();
                break;
            }
        }
    }

    private void SpawnObject()
    {
        int posPlayer = PosPlayer.instance.pos;
        int posEnemy = PosEnemy.instance.pos;
        if(posEnemy != posPlayer)
        {
            if (posPlayer != 0 && MovingManager.instance.SetActivePlayerMoving() && Map.Instance.Grass[posPlayer].childCount == 0 )
            {
                RandomPrefabs(Map.Instance.Grass[posPlayer], respawns, ratioRespawns);
            }
            else if (posEnemy != 0 && MovingManager.instance.SetActiveEnemyMoving() && Map.Instance.Grass[posEnemy].childCount == 0)
            {
                RandomPrefabs(Map.Instance.Grass[posEnemy], respawns, ratioRespawns);
            }
        }
        
    }


    //[SerializeField] private List<GameObject> prefabsStart;
    //[SerializeField] private GameObject win;
    //[SerializeField] private List<int> ratiosStart;
    //[SerializeField] private List<GameObject> respawns;
    //[SerializeField] private List<int> ratioRespawns;
    //private int totalRatio;
    //int posPlayerOld;
    //int posEnemyOld;

    //private Transform grassPos;
    //private static SpawnManager instance;

    //public static SpawnManager Instance => instance;

    //private void Awake()
    //{
    //    SpawnManager.instance = this;

    //    totalRatio = 0;
    //    foreach (var ratio in ratiosStart)
    //    {
    //        totalRatio += ratio;
    //    }

    //    for (int i = 1; i < Map.Instance.Grass.Count - 1; i++)
    //    {
    //        grassPos = Map.Instance.Grass[i];
    //        RandomPrefabs(grassPos, prefabsStart, ratiosStart);
    //    }
    //    grassPos = Map.Instance.Grass[Map.Instance.Grass.Count - 1];
    //    GameObject item = Instantiate(win, grassPos.position, Quaternion.identity, grassPos);
    //    item.name = item.name.Replace("(Clone)", "").Trim();

    //    totalRatio = 0;
    //    foreach (var ratio in ratioRespawns)
    //    {
    //        totalRatio += ratio;
    //    }
    //}

    //private void Update()
    //{
    //    SpawnObject();
    //}

    //private void RandomPrefabs(Transform grassPos, List<GameObject> prefabs, List<int> ratios)
    //{
    //    int randomValue = Random.Range(0, totalRatio);
    //    int cumulative = 0;

    //    for (int i = 0; i < prefabs.Count; i++)
    //    {
    //        cumulative += ratios[i];
    //        if (randomValue < cumulative)
    //        {
    //            if (prefabs[i] == null) break;
    //            GameObject item = Instantiate(prefabs[i], grassPos.position, Quaternion.identity, grassPos);

    //            item.name = item.name.Replace("(Clone)", "").Trim();
    //            break;
    //        }
    //    }
    //}

    //private void SpawnObject()
    //{
    //    if (MovingManager.instance.SetActivePlayerMoving())
    //    {
    //        posPlayerOld = PosPlayer.instance.pos;
    //    }
    //    else if (MovingManager.instance.SetActiveEnemyMoving())
    //    {
    //        posEnemyOld = PosEnemy.instance.pos;
    //    }
    //    if (posPlayerOld != 0 && !MovingManager.instance.SetActivePlayerMoving() && Map.Instance.Grass[posPlayerOld].childCount == 0 && posPlayerOld != PosEnemy.instance.pos)
    //    {
    //        RandomPrefabs(Map.Instance.Grass[posPlayerOld], respawns, ratioRespawns);
    //    }
    //    else if (posEnemyOld != 0 && !MovingManager.instance.SetActiveEnemyMoving() && Map.Instance.Grass[posEnemyOld].childCount == 0 && posEnemyOld != PosPlayer.instance.pos)
    //    {
    //        RandomPrefabs(Map.Instance.Grass[posEnemyOld], respawns, ratioRespawns);
    //    }
    //}
}
