using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoreUIManager : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] private GameObject Papiro;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextButton.onClick.AddListener(next);
        menuButton.onClick.AddListener(backToMenu);    
    }

    void next()
    {
        
    }
    
    void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
