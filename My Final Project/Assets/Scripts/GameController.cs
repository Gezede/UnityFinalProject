using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text canText; // Can miktarýný gösterecek olan UI Text
    public int maxCan = 100; // Maksimum can miktarý
    public int damageAmount = 10; // Çarpýþma sonrasý azalacak can miktarý
    private int can; // Mevcut can miktarý
    public GameObject gameOverPanel; // Oyun bitiþ paneli
    public GameObject settingsPanel;
    public GameObject finishPanel;
    private int coinScore = 0; // Toplanan coin puaný

    private bool gameIsOver = false; // Oyunun bitip bitmediðini kontrol etmek için flag
    void Start()
    {
        // Baþlangýçta can miktarýný ayarla
        can = maxCan;
        UpdateCanUI();
    }
    private void Update()
    {
        // Oyuncu 'ESC' tuþuna bastýðýnda ve oyun bitmediyse
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsOver)
        {
            // Finish paneli aktifleþtir
            finishPanel.SetActive(true);

            // Oyunu durdur
            Time.timeScale = 0f;
        }
    }
    public void CollectCoin(int coinValue)
    {
        coinScore += coinValue; // Toplanan coin puanýný artýr

        // Toplanan coin puaný 150'yi geçerse gameOverPanelini etkinleþtir
        if (coinScore >= 100)
        {
            ActivateGameOverPanel();
        }

    }
    public void IncreaseScore(int value)
    {
        coinScore += value; // Toplanan coin puanýný artýr
                            // Toplanan coin puaný 150'yi geçerse gameOverPanelini etkinleþtir
        if (coinScore >= 150)
        {
            ActivateGameOverPanel();
        }
    }
    public void ActivateGameOverPanel()
    {
        // Oyunu durdur
        Time.timeScale = 0f;

        // Oyun bitiþ panelini aktifleþtir
        gameOverPanel.SetActive(true);

        // Oyunun bittiðini belirten flag'i true yap
        gameIsOver = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Barrier"))
        {
            // Çarpýþma gerçekleþtiðinde caný azalt
            DecreaseHealth();
        }
        UpdateCanUI();
    }

    void DecreaseHealth()
    {// Can miktarýný azalt
        can -= damageAmount;

        if (can < 0)
        {
            can = 0;
        }
        // Can miktarý 0'dan küçükse, oyunu bitir
        if (can <= 0)
        {
            GameOver();
        }

        // Can miktarýný güncelle
        UpdateCanUI();
    }
    void UpdateCanUI()
    {
        // Can miktarýný UI Text'e yaz
        canText.text = "Can: " + can.ToString();
    }
    void GameOver()
    {
        // Oyunu bitir
        Debug.Log("Game Over!");
        finishPanel.SetActive(true);
    }

    // Restart butonuna basýldýðýnda oyunu yeniden baþlat
    public void RestartGame()
    {
        // Zaman ölçeðini geri al, oyunu yeniden baþlat
        Time.timeScale = 1f;

        // Aktif sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Main Menu butonuna basýldýðýnda ana menüye git
    public void MainMenu()
    {
        // Zaman ölçeðini geri al
        Time.timeScale = 1f;

        // Ana menü sahnesini yükle (varsayýlan olarak "Main Menu" sahnesi olacak)
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseGameOverPanel()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;

        // Oyun bitiþ panelini kapat
        gameOverPanel.SetActive(false);
    }
    public void NextMenu()
    {
        // Zaman ölçeðini geri al
        Time.timeScale = 1f;

        // Ana menü sahnesini yükle (varsayýlan olarak "Main Menu" sahnesi olacak)
        SceneManager.LoadScene("SecondScene");
    }
    public void OpenSettingsPanel()
    {
        // Oyunu devam ettir
        Time.timeScale = 1f;

        // Oyun bitiþ panelini kapat
        settingsPanel.SetActive(true);
    }
}