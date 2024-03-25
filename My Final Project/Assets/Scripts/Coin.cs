using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject collectEffect; // Efekt objesi
    public int coinValue = 10; // Coin'in de�eri
    public Text scoreText; // Canvas �zerindeki puan metni

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu taraf�ndan topland���nda efekti �a��r
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            // Coin topland���nda yap�lacak i�lemler
            Destroy(gameObject); // Coin nesnesini yok et
            FindObjectOfType<GameController>().IncreaseScore(coinValue); // Coin de�eri kadar puan artt�r
            IncreaseScore();
        }
    }

    void IncreaseScore()
    {
        // Puan� artt�r ve canvas �zerinde g�ncelle
        int currentScore = int.Parse(scoreText.text);
        currentScore += coinValue;
        scoreText.text = currentScore.ToString();
    }
}