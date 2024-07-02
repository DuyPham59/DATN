using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

public class BtnRollExitTrap : MonoBehaviour
{
    [SerializeField] private Button roll;
    private bool runOne;
    private Coroutine coroutine;
    public static BtnRollExitTrap instance;

    public Button Roll => roll;

    private void Awake()
    {
        BtnRollExitTrap.instance = this;
    }

    private void Update()
    {
        if (roll.gameObject.activeSelf && !runOne)
        {
            runOne = true;
            coroutine = StartCoroutine(AutoClick());
        }
    }

    public void ClickBtnRoll()
    {
        roll.gameObject.SetActive(false);
        StopCoroutine(coroutine);
        StartCoroutine(PlayerRollExitTrap.instance.BouncyDice());
        PlayerTime.instance.time.gameObject.SetActive(false);
        PlayerTime.instance.runOne = true;
    }

    IEnumerator AutoClick()
    {
        yield return new WaitForSeconds(30);
        roll.onClick.Invoke();
        runOne = false;
    }
}
