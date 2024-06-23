using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private static Map instance;
    private List<Transform> grass;

    public static Map Instance => instance;
    public List<Transform> Grass => grass;

    private void Awake()
    {
        Map.instance = this;
        grass = new List<Transform>();
        int grassCount = transform.childCount;
        for (int i = 0; i < grassCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            Grass.Add(childTransform);
        }
    }
}
