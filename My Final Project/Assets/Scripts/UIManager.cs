using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    public Text timerText; // Zamanlay�c� metin bile�eni
    public float gameTime = 150f; // Oyun s�resi

    private float timer; // Zamanlay�c� de�eri
    public GameObject settingsPanel;
    public GameObject infoPanel;
    public Button startGameButton; // Start game butonu
    public GameObject gameOverPanel;

    private void Start()
    {
        // Ba�lang��ta zamanlay�c� de�erini ayarla
        timer = gameTime;
        // Ba�lang��ta ayarlar panelini kapal� yap
        settingsPanel.SetActive(false);
        infoPanel.SetActive(false);
        // Start game butonuna t�kland���nda StartGame fonksiyonunu �a��r
        startGameButton.onClick.AddListener(StartGame);
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        // Zamanlay�c�y� g�ncelle
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // Zamanlay�c� s�f�r oldu�unda oyunu bitir veya ba�ka bir i�lem yap
            EndGame();
        }
    }
    void StartGame()
    {
        // Sample Scene sahnesine ge�i� yap
        SceneManager.LoadScene("SampleScene");
    }
    void EndGame()
    {
        // Oyunu bitir veya ba�ka bir i�lem yap
        Debug.Log("Oyun Bitti!");
        settingsPanel.SetActive(true);
    }
    void UpdateTimerUI()
    {
        // Zamanlay�c� metin bile�enini g�ncelle
        timerText.text = "Time: " + Mathf.Round(timer).ToString();
    }

    public void ToggleSettingsPanel()
    {
        // Settings butonuna t�kland���nda paneli a�/kapat
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
    public void CloseSettingsPanel()
    {
        // Settings butonuna t�kland���nda paneli a�/kapat
        settingsPanel.SetActive(false);
    }
    public void ToggleinfoPanel()
    {
        // Settings butonuna t�kland���nda paneli a�/kapat
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
    public void CloseinfoPanel()
    {
        // Settings butonuna t�kland���nda paneli a�/kapat
        infoPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Oyun Kapat�l�yor..."); // Opsiyonel: Debug mesaj�
        Application.Quit(); // Oyunu kapat
    }
}

