using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RollDice : MonoBehaviour
{
    protected int randomDice;
    protected string nameFaceDice;
    public int RandomDice { get => randomDice; }

    public virtual IEnumerator BouncyDice()
    {
        for (int i = 0; i < 5; i++)
        {
            Roll();
            yield return new WaitForSeconds(1);
            transform.Find(nameFaceDice).gameObject.SetActive(false);
        }
        //completeRoll = true;
    }
    protected void Roll()
    {
        randomDice = Random.Range(1, 7);
        nameFaceDice = "Dice" + randomDice;
        transform.Find(nameFaceDice).gameObject.SetActive(true);
    }
}
