using UnityEngine;
using UnityEngine.UI;

public class BtnDiffyculty : MonoBehaviour
{
    public int difficulty;
    public static BtnDiffyculty instance;
    public Button btnChooseDifficult;
    public Button btnDifficult1;
    public Button btnDifficult2;

    private void Awake()
    {
        BtnDiffyculty.instance = this;
    }

    public void OnClickChooseDifficult()
    {
        btnDifficult1.gameObject.SetActive(true);
        btnDifficult2.gameObject.SetActive(true);
        BtnChooseMap.instance.btnChooseMap.gameObject.SetActive(false);
        btnChooseDifficult.gameObject.SetActive(false);
        BtnExit.instance.btnExit.gameObject.SetActive(false);
        BtnPlay.instance.btnPlay.gameObject.SetActive(false);
    }

    public void OnClickDifficult1()
    {
        difficulty = 1;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        btnDifficult1.gameObject.SetActive(false);
        btnDifficult2.gameObject.SetActive(false);
        BtnChooseMap.instance.btnChooseMap.gameObject.SetActive(true);
        btnChooseDifficult.gameObject.SetActive(true);
        BtnExit.instance.btnExit.gameObject.SetActive(true);
        BtnPlay.instance.btnPlay.gameObject.SetActive(true);
    }

    public void OnClickDifficult2()
    {
        difficulty = 2;
        PlayerPrefs.SetInt("Difficulty", difficulty);
        btnDifficult1.gameObject.SetActive(false);
        btnDifficult2.gameObject.SetActive(false);
        BtnChooseMap.instance.btnChooseMap.gameObject.SetActive(true);
        btnChooseDifficult.gameObject.SetActive(true);
        BtnExit.instance.btnExit.gameObject.SetActive(true);
        BtnPlay.instance.btnPlay.gameObject.SetActive(true);
    }
}
