using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpEven : MonoBehaviour
{
    private int[] even= { 2, 4 ,6 };

    private void OnMouseDown()
    {       
        int evenRandom = Random.Range(0, even.Length);
        if (evenRandom == 0)
        {
            Debug.Log("mat xuc xac bang 2");
        }
        else if (evenRandom == 1)
        {
            Debug.Log("mat xuc xac bang 4");
        }
        else
        {
            Debug.Log("mat xuc xac bang 6");
        }
    }
}
