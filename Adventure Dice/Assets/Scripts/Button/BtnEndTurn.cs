using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEndTurn : MonoBehaviour
{
    [SerializeField] private Button endTurn;
    public static BtnEndTurn instance;

    public Button EndTurn => endTurn;

    private void Awake()
    {
        BtnEndTurn.instance = this;
    }
    public void ClickBtnRoll()
    {
        endTurn.gameObject.SetActive(false);
        BtnRollToMove.instance.Roll.gameObject.SetActive(false);
        Turn.instance.PlayerTurn = false;     
    }
}
