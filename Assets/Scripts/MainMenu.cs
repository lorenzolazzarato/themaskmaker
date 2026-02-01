using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton, soundButton, exitButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("IntroScene"); //aggiunere al prossimo livello
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
