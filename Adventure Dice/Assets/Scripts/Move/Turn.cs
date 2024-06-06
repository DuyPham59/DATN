using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private bool playerTurn;
    public static Turn instance;
    public bool PlayerTurn { get => playerTurn; set => playerTurn = value; }
    private void Awake()
    {
        Turn.instance = this;
    }
    private void Start()
    {
        int randomTurn = Random.Range(0,2);
        if (randomTurn == 0) { playerTurn = false; }
        else { playerTurn = true; BtnRollToMove.instance.Roll.gameObject.SetActive(true); }
    }
}
