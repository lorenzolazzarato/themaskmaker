using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoreUIManager : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] private GameObject papiro, client, shortReqPanel;
    [SerializeField] TMP_Text levelText;
    [SerializeField] Cliente testCliente;
    [SerializeField] private LocalizationAsset StringDatabase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{testCliente.userName}_request");
        nextButton.onClick.AddListener(next);
        menuButton.onClick.AddListener(backToMenu); 
        client.SetActive(true);
        shortReqPanel.SetActive(false);
    }

    void next()
    {
        papiro.SetActive(false);
        client.SetActive(false);
        shortReqPanel.SetActive(true);
    }
    
    void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
