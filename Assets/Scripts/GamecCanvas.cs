using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    [SerializeField] Button testButton;
    [SerializeField] GameObject PanelToShow;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
       testButton.onClick.AddListener(ShowPanel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowPanel()
    {
        PanelToShow.SetActive(true);
    }

}
