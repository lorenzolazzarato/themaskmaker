using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ShortReqPanelUI : MonoBehaviour
{
    [SerializeField] Button closeButton, moreButton;
    [SerializeField] TMP_Text shortTextReq, descrText;
    [SerializeField] DataCliente client;
    [SerializeField] GameObject PanelToShow;

    [SerializeField] GameObject MaskRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shortTextReq.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_request_review");
        closeButton.onClick.AddListener(ClosePanel);
        moreButton.onClick.AddListener(infoMenu);
        PanelToShow.SetActive(false);
        //nextButton.onClick.AddListener(NextText);
    }

    private void infoMenu()
    {
        descrText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"{client.displayName}_request");
        PanelToShow.SetActive(true);
        MaskRenderer.SetActive(false);
    }
    
    
    void ClosePanel()
    {
        PanelToShow.SetActive(false);
        MaskRenderer.SetActive(true);
    }
}
