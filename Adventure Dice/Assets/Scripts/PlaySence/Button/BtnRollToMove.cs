using UnityEngine;
using UnityEngine.UI;

public class BtnRollToMove : MonoBehaviour
{
    [SerializeField] private Button roll;
    public static BtnRollToMove instance;
    public bool rollOne;

    public Button Roll => roll;

    private void Awake()
    {       
        BtnRollToMove.instance = this;
    }

    private void Update()
    {
        if(!Turn.instance.PlayerTurn) {
            rollOne = false;
        }
    }

    public void ClickBtnRoll()
    {
        roll.gameObject.SetActive(false);
        StartCoroutine(PlayerRollToMove.instance.BouncyDice());
        rollOne = true;
        BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
        PlayerTime.instance.time.gameObject.SetActive(false);
        PlayerTime.instance.runOne = true;
    }
}
