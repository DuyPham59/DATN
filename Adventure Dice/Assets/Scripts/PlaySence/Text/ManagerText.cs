using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManagerText : MonoBehaviour
{
    public static ManagerText instance;
    public Text textWin;
    public Text textNotification;
    public Text textTurn;

    private void Awake()
    {
        ManagerText.instance = this;
    }
}
