using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpOdd : MonoBehaviour
{
    private int[] odd = { 1, 3, 5 };

    private void OnMouseDown()
    {
        int evenRandom = Random.Range(0, odd.Length);
        if (evenRandom == 0)
        {
            Debug.Log("mat xuc xac bang 1");
        }
        else if (evenRandom == 1)
        {
            Debug.Log("mat xuc xac bang 3");
        }
        else
        {
            Debug.Log("mat xuc xac bang 5");
        }
    }
}
