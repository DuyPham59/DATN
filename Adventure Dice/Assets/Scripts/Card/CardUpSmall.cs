using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpSmall : MonoBehaviour
{
    private int[] small = { 1, 2, 3 };

    private void OnMouseDown()
    {
        int evenRandom = Random.Range(0, small.Length);
        if (evenRandom == 0)
        {
            Debug.Log("mat xuc xac bang 1");
        }
        else if (evenRandom == 1)
        {
            Debug.Log("mat xuc xac bang 2");
        }
        else
        {
            Debug.Log("mat xuc xac bang 3");
        }
    }
}
