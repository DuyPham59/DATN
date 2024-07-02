using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BtnRollAttack : MonoBehaviour
{
    public Button roll;
    private bool runOne;
    private Coroutine coroutine;
    public static BtnRollAttack instance;

    public Button Roll => roll;

    private void Awake()
    {
        BtnRollAttack.instance = this;
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
        StartCoroutine(PlayerRollAttack.instance.BouncyDice());
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
