using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    public Text timerText; // Zamanlayýcý metin bileþeni
    public float gameTime = 150f; // Oyun süresi

    private float timer; // Zamanlayýcý deðeri
    public GameObject settingsPanel;
    public GameObject infoPanel;
    public Button startGameButton; // Start game butonu
    public GameObject gameOverPanel;

    private void Start()
    {
        // Baþlangýçta zamanlayýcý deðerini ayarla
        timer = gameTime;
        // Baþlangýçta ayarlar panelini kapalý yap
        settingsPanel.SetActive(false);
        infoPanel.SetActive(false);
        // Start game butonuna týklandýðýnda StartGame fonksiyonunu çaðýr
        startGameButton.onClick.AddListener(StartGame);
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        // Zamanlayýcýyý güncelle
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // Zamanlayýcý sýfýr olduðunda oyunu bitir veya baþka bir iþlem yap
            EndGame();
        }
    }
    void StartGame()
    {
        // Sample Scene sahnesine geçiþ yap
        SceneManager.LoadScene("SampleScene");
    }
    void EndGame()
    {
        // Oyunu bitir veya baþka bir iþlem yap
        Debug.Log("Oyun Bitti!");
        settingsPanel.SetActive(true);
    }
    void UpdateTimerUI()
    {
        // Zamanlayýcý metin bileþenini güncelle
        timerText.text = "Time: " + Mathf.Round(timer).ToString();
    }

    public void ToggleSettingsPanel()
    {
        // Settings butonuna týklandýðýnda paneli aç/kapat
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
    public void CloseSettingsPanel()
    {
        // Settings butonuna týklandýðýnda paneli aç/kapat
        settingsPanel.SetActive(false);
    }
    public void ToggleinfoPanel()
    {
        // Settings butonuna týklandýðýnda paneli aç/kapat
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
    public void CloseinfoPanel()
    {
        // Settings butonuna týklandýðýnda paneli aç/kapat
        infoPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Oyun Kapatýlýyor..."); // Opsiyonel: Debug mesajý
        Application.Quit(); // Oyunu kapat
    }
}

