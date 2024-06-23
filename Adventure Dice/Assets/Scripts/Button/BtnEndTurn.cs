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
        Turn.instance.PlayerTurn = false;
    }
}
