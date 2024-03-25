using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text canText; // Can miktar�n� g�sterecek olan UI Text
    public int maxCan = 100; // Maksimum can miktar�
    public int damageAmount = 10; // �arp��ma sonras� azalacak can miktar�
    private int can; // Mevcut can miktar�
    public GameObject gameOverPanel; // Oyun biti� paneli
    public GameObject settingsPanel;
    public GameObject finishPanel;
    private int coinScore = 0; // Toplanan coin puan�

    private bool gameIsOver = false; // Oyunun bitip bitmedi�ini kontrol etmek i�in flag
    void Start()
    {
        // Ba�lang��ta can miktar�n� ayarla
        can = maxCan;
        UpdateCanUI();
    }
    private void Update()
    {
        // Oyuncu 'ESC' tu�una bast���nda ve oyun bitmediyse
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsOver)
        {
            // Finish paneli aktifle�tir
            finishPanel.SetActive(true);

            // Oyunu durdur
            Time.timeScale = 0f;
        }
    }
    public void CollectCoin(int coinValue)
    {
        coinScore += coinValue; // Toplanan coin puan�n� art�r

        // Toplanan coin puan� 150'yi ge�erse gameOverPanelini etkinle�tir
        if (coinScore >= 100)
        {
            ActivateGameOverPanel();
        }

    }
    public void IncreaseScore(int value)
    {
        coinScore += value; // Toplanan coin puan�n� art�r
                            // Toplanan coin puan� 150'yi ge�erse gameOverPanelini etkinle�tir
        if (coinScore >= 150)
        {
            ActivateGameOverPanel();
        }
    }
    public void ActivateGameOverPanel()
    {
        // Oyunu durdur
        Time.timeScale = 0f;

        // Oyun biti� panelini aktifle�tir
        gameOverPanel.SetActive(true);

        // Oyunun bitti�ini belirten flag'i true yap
        gameIsOver = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Barrier"))
        {
            // �arp��ma ger�ekle�ti�inde can� azalt
            DecreaseHealth();
        }
        UpdateCanUI();
    }

    void DecreaseHealth()
    {// Can miktar�n� azalt
        can -= damageAmount;

        if (can < 0)
        {
            can = 0;
        }
        // Can miktar� 0'dan k���kse, oyunu bitir
        if (can <= 0)
        {
            GameOver();
        }

        // Can miktar�n� g�ncelle
        UpdateCanUI();
    }
    void UpdateCanUI()
    {
        // Can miktar�n� UI Text'e yaz
        canText.text = "Can: " + can.ToString();
    }
    void GameOver()
    {
        // Oyunu bitir
        Debug.Log("Game Over!");
        finishPanel.SetActive(true);
    }

    // Restart butonuna bas�ld���nda oyunu yeniden ba�lat
    public void RestartGame()
    {
        // Zaman �l�e�ini geri al, oyunu yeniden ba�lat
        Time.timeScale = 1f;

        // Aktif sahneyi yeniden y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Main Menu butonuna bas�ld���nda ana men�ye git
    public void MainMenu()
    {
        // Zaman �l�e�ini geri al
        Time.timeScale = 1f;

        // Ana men� sahnesini y�kle (varsay�lan olarak "Main Menu" sahnesi olacak)
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseGameOverPanel()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;

        // Oyun biti� panelini kapat
        gameOverPanel.SetActive(false);
    }
    public void NextMenu()
    {
        // Zaman �l�e�ini geri al
        Time.timeScale = 1f;

        // Ana men� sahnesini y�kle (varsay�lan olarak "Main Menu" sahnesi olacak)
        SceneManager.LoadScene("SecondScene");
    }
    public void OpenSettingsPanel()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;

        // Oyun biti� panelini kapat
        settingsPanel.SetActive(true);
    }
}