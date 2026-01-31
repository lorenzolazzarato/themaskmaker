using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class descrPanel : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] Button nextButton;
    [SerializeField] TextMeshProUGUI descrText;
    
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	SetText("pippo pluto");
        closeButton.onClick.AddListener(ClosePanel);
        nextButton.onClick.AddListener(NextText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SetText(string text)
    {
    	descrText.text = text;
    }
    
    void ClosePanel()
    {
    	gameObject.SetActive(false);
    	SetText("pippo pluto");
    }
    
    void NextText()
    {
    	descrText.text = "paperino";
    }
}
