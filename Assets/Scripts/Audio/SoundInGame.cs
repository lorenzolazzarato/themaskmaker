using UnityEngine;
using UnityEngine.UI;

public class SoundInGame : MonoBehaviour
{
    [SerializeField] Button beforeButton ,nextButton, confirmButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beforeButton.onClick.AddListener(clickbotton);
        nextButton.onClick.AddListener(clickbotton);
        confirmButton.onClick.AddListener(clickbotton);
    }
    void clickbotton()
    {
        AudioManager.instance.Play("clickbutton");
    }
}
