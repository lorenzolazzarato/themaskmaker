using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoreUIManager : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] private GameObject papiro, shortReqPanel;

    [SerializeField] DataCliente client;
    [SerializeField] TMP_Text levelText;
    [SerializeField] SpriteRenderer spriteClient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.Play("catherine");
        Debug.Log(client.displayName);
        levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_request");
        spriteClient.sprite = client.sprite;
        nextButton.onClick.AddListener(Next);
        menuButton.onClick.AddListener(BackToMenu); 
        shortReqPanel.SetActive(false);
    }

    void Next()
    {
        AudioManager.instance.Play("botClick");
        papiro.SetActive(false);
        shortReqPanel.SetActive(true);
        spriteClient.sprite = null;
    }
    
    void BackToMenu()
    {
        AudioManager.instance.Play("botClick");
        AudioManager.instance.Stop("catherine");
        SceneManager.LoadScene(0);
    }
}
