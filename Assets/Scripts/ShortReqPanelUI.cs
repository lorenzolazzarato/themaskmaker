using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortReqPanelUI : MonoBehaviour
{
    [SerializeField] Button closeButton, nextButton, moreButton;
    [SerializeField] TMP_Text shortTextReq, descrText;
    [SerializeField] Cliente client;
    [SerializeField] GameObject PanelToShow;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shortTextReq.text = client.getShortReq();
        closeButton.onClick.AddListener(ClosePanel);
        moreButton.onClick.AddListener(infoMenu);
        PanelToShow.SetActive(false);
        //nextButton.onClick.AddListener(NextText);
    }

    private void infoMenu()
    {
        descrText.text = client.getDescr();
        PanelToShow.SetActive(true);
    }
    
    
    void ClosePanel()
    {
        PanelToShow.SetActive(false);
    }
}
