using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    [SerializeField] private Text time;
    private float updateTime;
    private int seconds;

    private void Awake()
    {
        seconds = 30;
        updateTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - updateTime > 1)
        {
            updateTime = Time.time;
            seconds = seconds - 1;
            time.text = "Time : " + seconds; 
        }

        if (seconds == 0)
        {
            gameObject.SetActive(false);
            BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
            BtnRollToMove.instance.Roll.gameObject.SetActive(false);
            Turn.instance.PlayerTurn = false;
        }
    }
}
