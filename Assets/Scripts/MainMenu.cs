using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton, soundButton, exitButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.Play("title");
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        AudioManager.instance.Play("clickbutton");
        SceneManager.LoadScene("IntroScene"); 
        AudioManager.instance.Stop("title");
    }

    private void QuitGame()
    {
        AudioManager.instance.Play("clickbutton");
        Application.Quit();
    }
    
}
