using UnityEngine;

public class ManagerButton : MonoBehaviour
{
    private bool runOne;

    private void Awake()
    {
        runOne = true;
    }

    void Update()
    {
        if (Turn.instance.PlayerTurn && runOne == true && Map.Instance.Grass[PosPlayer.instance.pos].childCount == 0)
        {
            runOne = false;
            PlayerTime.instance.time.gameObject.SetActive(true);
            BtnEndTurn.instance.EndTurn.gameObject.SetActive(true);
            BtnRollToMove.instance.Roll.gameObject.SetActive(true);
        }

        if (!Turn.instance.PlayerTurn && runOne == false)
        {
            PlayerTime.instance.time.gameObject.SetActive(false);
            PlayerTime.instance.runOne = true;
            BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
            BtnRollToMove.instance.Roll.gameObject.SetActive(false);
            runOne = true;
        }
    }
}
