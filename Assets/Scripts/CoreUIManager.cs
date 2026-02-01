using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoreUIManager : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] private GameObject papiro, shortReqPanel;

    [SerializeField] List<DataCliente> clientList;
    [SerializeField] TMP_Text levelText;
    [SerializeField] SpriteRenderer spriteClient;

    private DataCliente client;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.clientId = clientList[UnityEngine.Random.Range(0, clientList.Count)];
        client = GameManager.clientId;
        Debug.Log(client.displayName);
        levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_request");
        spriteClient.sprite = client.sprite;
        nextButton.onClick.AddListener(Next);
        menuButton.onClick.AddListener(BackToMenu); 
        shortReqPanel.SetActive(false);
    }

    void Next()
    {
        //papiro.SetActive(false);
        //shortReqPanel.SetActive(true);
        //spriteClient.sprite = null;

        SceneManager.LoadScene("GameplayScene");
    }
    
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
