using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpBig : MonoBehaviour
{
    private int[] big = { 4, 5, 6 };

    private void OnMouseDown()
    {
        int evenRandom = Random.Range(0, big.Length);
        if (evenRandom == 0)
        {
            Debug.Log("mat xuc xac bang 4");
        }
        else if (evenRandom == 1)
        {
            Debug.Log("mat xuc xac bang 5");
        }
        else
        {
            Debug.Log("mat xuc xac bang 6");
        }
    }
}
