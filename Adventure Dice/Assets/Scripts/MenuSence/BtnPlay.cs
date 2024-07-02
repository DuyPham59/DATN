using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnPlay : MonoBehaviour
{
    public static BtnPlay instance;
    public Button btnPlay;

    private void Awake()
    {
        BtnPlay.instance = this;
    }
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
