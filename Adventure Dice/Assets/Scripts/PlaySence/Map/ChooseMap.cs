using UnityEngine;

public class ChooseMap : MonoBehaviour
{
    public static ChooseMap instance;
    [SerializeField] private GameObject backGround1;
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject backGround2;
    [SerializeField] private GameObject map2;
    private int chooseMap;

    private void Awake()
    {
        ChooseMap.instance = this;
        chooseMap = BtnChooseMap.instance.map;
        if (chooseMap <= 1)
        {
            backGround1.SetActive(true);
            map1.SetActive(true);
        }
        else
        {
            backGround2.SetActive(true);
            map2.SetActive(true);
        }
    }
}
