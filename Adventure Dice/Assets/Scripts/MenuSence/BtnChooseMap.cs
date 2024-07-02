using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnChooseMap : MonoBehaviour
{
    public int map;
    public static BtnChooseMap instance;
    public Button btnChooseMap;
    public GameObject map1;
    public GameObject map2;

    private void Awake()
    {
        BtnChooseMap.instance = this;
    }

    public void OnClickBtnChooseMap()
    {
        map1.SetActive(true);
        map2.SetActive(true);
        btnChooseMap.gameObject.SetActive(false);
        BtnDiffyculty.instance.btnChooseDifficult.gameObject.SetActive(false);
        BtnExit.instance.btnExit.gameObject.SetActive(false);
        BtnPlay.instance.btnPlay.gameObject.SetActive(false);
    }
}
