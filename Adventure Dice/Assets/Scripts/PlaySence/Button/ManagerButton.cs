using UnityEngine;

public class ManagerButton : MonoBehaviour
{
    private bool runOne;
    private bool checkOne;
    private bool playerTrap;
    public static ManagerButton instance;

    private void Awake()
    {
        runOne = true;
        ManagerButton.instance = this;
    }

    void Update()
    {
        if (Turn.instance.PlayerTurn)
        {
            if (runOne)
            {
                runOne = false;
                if (Map.Instance.Grass[PosPlayer.instance.pos].childCount != 0 && Map.Instance.Grass[PosPlayer.instance.pos].GetChild(0).name == "ItemTrap")
                {
                    playerTrap = true;      
                }
                else
                {
                    playerTrap = false;
                }
            }

            if (!playerTrap && Map.Instance.Grass[PosPlayer.instance.pos].childCount == 0 && !BtnRollToMove.instance.rollOne)
            {
                BtnRollToMove.instance.Roll.gameObject.SetActive(true);
            }

            if (Map.Instance.Grass[PosPlayer.instance.pos].childCount == 0 && !MovingManager.instance.SetActivePlayerMoving() && !checkOne)
            {
                checkOne = true;
                BtnEndTurn.instance.EndTurn.gameObject.SetActive(true);
            }
            if (MovingManager.instance.SetActivePlayerMoving() || MovingManager.instance.SetActiveEnemyMoving())
            {
                BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
                checkOne = false;
            }

            if (BtnRollAttack.instance.Roll.gameObject.activeSelf || BtnRollExitTrap.instance.Roll.gameObject.activeSelf)
            {
                BtnEndTurn.instance.EndTurn.gameObject.SetActive(false);
                BtnRollToMove.instance.Roll.gameObject.SetActive(false);
                PlayerTime.instance.time.gameObject.SetActive(true);
            }

            if(BtnRollToMove.instance.Roll.gameObject.activeSelf)
            {
                PlayerTime.instance.time.gameObject.SetActive(true);
            }
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
