using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMap2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        BtnChooseMap.instance.map = 2;
        PlayerPrefs.SetInt("Map", BtnChooseMap.instance.map);
        BtnChooseMap.instance.btnChooseMap.gameObject.SetActive(true);
        BtnDiffyculty.instance.btnChooseDifficult.gameObject.SetActive(true);
        BtnExit.instance.btnExit.gameObject.SetActive(true);
        BtnPlay.instance.btnPlay.gameObject.SetActive(true);
        BtnChooseMap.instance.map1.SetActive(false);
        BtnChooseMap.instance.map2.SetActive(false);
    }
}
