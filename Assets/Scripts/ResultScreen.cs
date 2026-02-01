using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] Button restartButton, menuButton;
    [SerializeField] private SpriteRenderer clientSprite, woodSprite, faceSprite, runeSprite;
    [SerializeField] TMP_Text resultText;
    private DataCliente client;
    private MaskWoodType playerWood;
    private MaskFaceType playerFace;
    private MaskRuneType playerRune;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        client = GameManager.clientId;
        clientSprite.sprite = client.sprite;
        playerWood = GameManager.mask.woodType;
        playerFace = GameManager.mask.faceType;
        playerRune = GameManager.mask.runeType;
        woodSprite.sprite = playerWood.sprite;
        faceSprite.sprite = playerFace.sprite;
        runeSprite.sprite = playerRune.sprite;
        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(BackToMenu);
        if (client.woodID == playerWood.id && client.faceID == playerFace.id && client.runeID == playerRune.id)
        {
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_positive_result");
        }
        else if (client.woodID != playerWood.id && client.faceID != playerFace.id && client.runeID != playerRune.id)
        {
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_negative_result");
        }
        else
        {
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_neutral_result");
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("ClienteTest");        
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
