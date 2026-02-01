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
    [SerializeField] TMP_Text buttonText;

    private DataCliente client;
    private MaskWoodType playerWood;
    private MaskFaceType playerFace;
    private MaskRuneType playerRune;

    private bool maskCorrect = false;
    private bool totalWinner = false;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.clientId.userID == 0)
        {
            AudioManager.instance.Stop("catherine");
        }
        else if (GameManager.clientId.userID == 1)
        {
            AudioManager.instance.Stop("alphonse");
        }
        else
        {
            AudioManager.instance.Stop("urian");
        }
        AudioManager.instance.Play("endgame");
        client = GameManager.clientId;
        if(client.sprite != null)
            clientSprite.sprite = client.sprite;
        playerWood = GameManager.mask.woodType;
        playerFace = GameManager.mask.faceType;
        playerRune = GameManager.mask.runeType;
        woodSprite.sprite = playerWood.sprite;
        faceSprite.sprite = playerFace.sprite;
        runeSprite.sprite = playerRune.sprite;
        menuButton.onClick.AddListener(BackToMenu);
        if (client.woodID == playerWood.id && client.faceID == playerFace.id && client.runeID == playerRune.id)
        {
            totalWinner = true;
            AudioManager.instance.Stop("endgame");
            AudioManager.instance.Play("success");
            maskCorrect = true;
            buttonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"ui_button_text_next_client");
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_positive_result");
        }
        else if (client.woodID != playerWood.id && client.faceID != playerFace.id && client.runeID != playerRune.id)
        {
            maskCorrect = false;
            buttonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"ui_button_text_retry");
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_negative_result");
        }
        else
        {
            maskCorrect = false;
            buttonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"ui_button_text_retry");
            resultText.text= LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_neutral_result");
        }
    }

    public void Restart()
    {
        if (totalWinner)
        {
            AudioManager.instance.Stop("success");
        }
        else
        {
            AudioManager.instance.Stop("endgame");
        }
        Debug.Log("dio");
        if (maskCorrect)
        {
            
            SceneManager.LoadScene("ClienteTest");
            
        } else
        {
            if (GameManager.clientId.userID == 0)
            {
                AudioManager.instance.Play("catherine");
            }
            else if (GameManager.clientId.userID == 1)
            {
                AudioManager.instance.Play("alphonse");
            }
            else
            {
                AudioManager.instance.Play("urian");
            }
            SceneManager.LoadScene("GameplayScene");
        }
             
    }

    void BackToMenu()
    {
        if (totalWinner)
        {
            AudioManager.instance.Stop("success");
        }
        else
        {
            AudioManager.instance.Stop("endgame");
        }
        AudioManager.instance.Play("clickbutton");
        SceneManager.LoadScene("MainMenu");
    }
}
