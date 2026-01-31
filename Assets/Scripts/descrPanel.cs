using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panel : MonoBehaviour
{
    [SerializeField] Button closeButton;
    
    void Start()
    {
        closeButton.onClick.AddListener(ClosePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ClosePanel()
    {
    	gameObject.SetActive(false);
    }
}
