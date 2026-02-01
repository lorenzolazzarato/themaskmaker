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
        if (client.userID == 0)
        {
            AudioManager.instance.Play("catherine");
        }
        else if (client.userID == 1)
        {
            AudioManager.instance.Play("alphonse");
        }
        else
        {
            AudioManager.instance.Play("urian");
        }
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
        AudioManager.instance.Play("clickbutton");
        SceneManager.LoadScene("GameplayScene");
    }
    
    void BackToMenu()
    {
        AudioManager.instance.Play("clickbutton");
        if (client.userID == 0)
        {
            AudioManager.instance.Stop("catherine");
        }
        else if (client.userID == 1)
        {
            AudioManager.instance.Stop("alphonse");
        }
        else
        {
            AudioManager.instance.Stop("urian");
        }
        SceneManager.LoadScene(0);
    }
}
