using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnExit : MonoBehaviour
{
    public static BtnExit instance;
    public Button btnExit;

    private void Awake()
    {
            BtnExit.instance = this;
    }
    public void OnClick()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}
