using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private bool runOne;
    private void Update()
    {
        if(PosPlayer.instance.pos == (Map.Instance.Grass.Count - 1) && !runOne)
        {
            runOne = true;
            StartCoroutine(TextWin("Player"));
        }
        else if(PosEnemy.instance.pos == (Map.Instance.Grass.Count -1) && !runOne)
        {
            runOne = true;
            StartCoroutine(TextWin("Enemy"));
        }
    }

    IEnumerator TextWin(string whoWin)
    {
        yield return new WaitForSeconds(3);
        if(whoWin == "Player")
        {
            ManagerText.instance.textWin.gameObject.SetActive(true);
            ManagerText.instance.textWin.text = "Ban da thang";
            SceneManager.LoadScene(0);
        }
        else if(whoWin == "Enemy")
        {
            ManagerText.instance.textWin.gameObject.SetActive(true) ;
            ManagerText.instance.textWin.text = "Ban da thua";
            SceneManager.LoadScene(0);
        }
    }
}
