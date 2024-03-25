using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject collectEffect; // Efekt objesi
    public int coinValue = 10; // Coin'in deðeri
    public Text scoreText; // Canvas üzerindeki puan metni

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu tarafýndan toplandýðýnda efekti çaðýr
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            // Coin toplandýðýnda yapýlacak iþlemler
            Destroy(gameObject); // Coin nesnesini yok et
            FindObjectOfType<GameController>().IncreaseScore(coinValue); // Coin deðeri kadar puan arttýr
            IncreaseScore();
        }
    }

    void IncreaseScore()
    {
        // Puaný arttýr ve canvas üzerinde güncelle
        int currentScore = int.Parse(scoreText.text);
        currentScore += coinValue;
        scoreText.text = currentScore.ToString();
    }
}