using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Boss
{
    protected override void Awake()
    {
        base.Awake();
        lengthArray = 2;
        arrayDiceDefeatBoss = new int[lengthArray];
    }
}
