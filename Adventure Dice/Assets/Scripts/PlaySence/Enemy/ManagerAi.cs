using UnityEngine;

public class ManagerAi : MonoBehaviour
{
    public static ManagerAi instance;
    [SerializeField] private GameObject AIEnemy1;
    [SerializeField] private GameObject AIEnemy2;
    private int difficult;

    private void Awake()
    {
        ManagerAi.instance = this;
    }

    private void OnEnable()
    {
        difficult = BtnDiffyculty.instance.difficulty;
        if (difficult <= 1)
        {
            AIEnemy1.gameObject.SetActive(true);
        }
        else
            AIEnemy2.gameObject.SetActive(true);
    }
}
