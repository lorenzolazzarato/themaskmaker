using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialUI2 : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] TMP_Text levelText;
    private int readText = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"intro_1");
        levelText.fontStyle = FontStyles.Italic;
    }

    void Start()
    {
        
        nextButton.onClick.AddListener(nextText);
        menuButton.onClick.AddListener(backToMenu);
    }

    void nextText()
    {
        if (readText == 0 && levelText != null)
        {
            levelText.fontStyle = FontStyles.Italic;
            levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"intro_2");
        }
        else if (readText == 1 && levelText != null)
        {
            levelText.fontStyle = FontStyles.Italic;
            levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"intro_3");            
        }
        else if (readText == 2 && levelText != null)
        {
            levelText.fontStyle = FontStyles.Normal;
            levelText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"intro_4");
        }
        else
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //aggiunere al prossimo livello
        }
        readText++;
    }

    void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
