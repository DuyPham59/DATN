using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> cardList;
    private bool randomCard;
    private GameObject card;
    public static CardManager instance;

    public GameObject Card => card;

    private void Awake()
    {
        CardManager.instance = this;
        //cardList = new List<GameObject>(); 
    }
    void Update()
    {
        //    if(randomCard)
        //    {
        //        randomCard = false;
        //        // Khởi tạo một mảng để lưu trữ xác suất xuất hiện của mỗi thẻ bài
        //        float[] cardProbabilities = new float[cardList.Count];

        //        // Tính tổng xác suất của tất cả các thẻ bài
        //        float totalProbability = 0f;
        //        for (int i = 0; i < cardList.Count; i++)
        //        {
        //            // Tính toán xác suất cho mỗi thẻ bài (có thể là xác suất ngẫu nhiên)
        //            cardProbabilities[i] = Random.Range(0.0f, 1.0f); // Ví dụ: xác suất ngẫu nhiên từ 0 đến 1
        //            totalProbability += cardProbabilities[i];
        //        }

        //        // Chuẩn hóa xác suất để tổng xác suất bằng 1
        //        for (int i = 0; i < cardList.Count; i++)
        //        {
        //            cardProbabilities[i] /= totalProbability;
        //        }

        //        // Tạo một phân phối ngẫu nhiên dựa trên xác suất đã chuẩn hóa
        //        float randomValue = Random.Range(0.0f, 1.0f);
        //        float cumulativeProbability = 0f;
        //        for (int i = 0; i < cardList.Count; i++)
        //        {
        //            cumulativeProbability += cardProbabilities[i];
        //            if (randomValue <= cumulativeProbability)
        //            {
        //                // Instantiate thẻ bài tương ứng
        //                card = Instantiate(cardList[i], transform.position, Quaternion.identity);
        //                break; // Kết thúc vòng lặp khi đã chọn thẻ bài
        //            }
        //        }
        //    }
        //}
    }
}
