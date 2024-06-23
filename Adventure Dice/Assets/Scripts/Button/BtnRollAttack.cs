using UnityEngine;
using UnityEngine.UI;

public class BtnRollAttack : MonoBehaviour
{
    public Button roll;
    public static BtnRollAttack instance;

    public Button Roll => roll;

    private void Awake()
    {
        BtnRollAttack.instance = this;
    }

    public void ClickBtnRoll()
    {
        roll.gameObject.SetActive(false);
        StartCoroutine(PlayerRollAttack.instance.BouncyDice());
    }
}
