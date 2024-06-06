using UnityEngine;
using UnityEngine.UI;

public class BtnRollToMove : MonoBehaviour
{
    [SerializeField] private Button roll;
    public static BtnRollToMove instance;

    public Button Roll => roll;

    private void Awake()
    {
        PlayerRollToMove.instance.CompleteRollToMove = false;
        BtnRollToMove.instance = this;
    }
    public void ClickBtnRoll()
    {
        roll.gameObject.SetActive(false);
        StartCoroutine(PlayerRollToMove.instance.BouncyDice());
    }
}
