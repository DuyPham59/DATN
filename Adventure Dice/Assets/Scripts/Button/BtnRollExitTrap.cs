using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnRollExitTrap : MonoBehaviour
{
    [SerializeField] private Button roll;
    public static BtnRollExitTrap instance;

    public Button Roll => roll;

    private void Awake()
    {
        BtnRollExitTrap.instance = this;
    }

    public void ClickBtnRoll()
    {
        roll.gameObject.SetActive(false);
        StartCoroutine(PlayerRollExitTrap.instance.BouncyDice());
    }
}
