using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BtnEndTurn : MonoBehaviour
{
    [SerializeField] private Button endTurn;
    private bool runOne;
    private Coroutine coroutine;
    public static BtnEndTurn instance;

    public Button EndTurn => endTurn;

    private void Awake()
    {
        BtnEndTurn.instance = this;
    }

    private void Update()
    {
        if (endTurn.gameObject.activeSelf && !runOne)
        {
            runOne = true;
            coroutine = StartCoroutine(AutoClick());
        }

        if (!endTurn.gameObject.activeSelf && coroutine != null)
        {
            StopCoroutine(coroutine);
            runOne = false;
        }
    }

    public void ClickBtnRoll()
    {
        StopCoroutine(coroutine);
        Turn.instance.PlayerTurn = false;
    }

    IEnumerator AutoClick()
    {
        yield return new WaitForSeconds(30);
        endTurn.onClick.Invoke();
        runOne = false;
    }
}
