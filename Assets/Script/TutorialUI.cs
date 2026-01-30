using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] TMP_Text levelText;
    private int readText = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.text = "The crooked cart squeals for each push you give it up the bright green hillside leading up to Aimendell. The crisp morning breeze is starting to feel unpleasant on your forehead and neck, beaded with sweat.\n\n“A strapping young lad like ye will have no trouble carrying this ol’ thing around I reckon”\nSihgur’s jolly voice plays on repeat in your mind as you curse at the skies when yet another stone lodges itself beneath one of the wheels, halting its stride once more. \n\nHe really didn’t need to build this wreck out of heftknot, sure it’s steady but way too heavy. \n\nSihgur was like that. You sigh and push forward.\n";
        nextButton.onClick.AddListener(nextText);
        menuButton.onClick.AddListener(backToMenu);
    }

    void nextText()
    {
        if (readText == 0)
        {
            levelText.text = "23";
        }
        else if (readText == 1)
        {
            levelText.text = "3";
        }
        else
        {
            SceneManager.LoadScene("MainMenu"); //aggiunere al prossimo livello
        }
        readText++;
    }

    void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
