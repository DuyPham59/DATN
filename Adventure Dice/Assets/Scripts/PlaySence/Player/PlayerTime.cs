using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    public static PlayerTime instance;
    public bool runOne;
    public Text time;
    private float updateTime;
    private int seconds;

    private void Awake()
    {
        PlayerTime.instance = this;
        runOne = true;
    }

    private void Update()
    {
        if (Turn.instance.PlayerTurn && runOne)
        {
            runOne = false;
            seconds = 30;
            time.text = "Thời gian : " + seconds;
            updateTime = UnityEngine.Time.time;
        }

        if (time.gameObject.activeSelf)
        {
            if (UnityEngine.Time.time - updateTime > 1 && !MovingManager.instance.SetActivePlayerMoving() && seconds>0)
            {
                updateTime = UnityEngine.Time.time;
                seconds = seconds - 1;
                time.text = "Thời gian : " + seconds;
            }
        }      
    }
}
