using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoClienteUI : MonoBehaviour
{
    [SerializeField] Button nextButton, menuButton;
    [SerializeField] TMP_Text levelText;
    private int readText = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.fontStyle = FontStyles.Italic;
        levelText.text = "The crooked cart squeals for each push you give it up the bright green hillside leading up to Aimendell. The crisp morning breeze is starting to feel unpleasant on your forehead and neck, beaded with sweat.\n \n“A strapping young lad like ye will have no trouble carrying this ol’ thing around I reckon” \n Sihgur’s jolly voice plays on repeat in your mind as you curse at the skies when yet another stone lodges itself beneath one of the wheels, halting its stride once more. \n \n He really didn’t need to build this wreck out of heftknot, sure it’s steady but way too heavy. \n \n Sihgur was like that. You sigh and push forward.\n";
        nextButton.onClick.AddListener(nextText);
        menuButton.onClick.AddListener(backToMenu);
    }

    void nextText()
    {
        if (readText == 0)
        {
            levelText.fontStyle = FontStyles.Italic;
            levelText.text = "Before the large stone brick walls cast their shade on you, you pick up the faint merry melodies of flutes and tambourines accompanied by the scent of caramel mixed with hardy roasted beef and frothy ale.\n \nThen, the imposing sturdy heftknot gate looks down upon you opening to an unpaved road. You swear you can see a mocking grin in its gnarls.\n \n You find a good spot in the shade of a beautiful fairlily tree and with an exasperated sign, you let go of the handles of your cart. You set your tools on your workbench, your materials and lastly a dusty cloth to showcase your creations on your stand. \n \nMany curious eyes eagerly follow your movements, drawn firstly to the novelty of your person in this town but then mostly to the arcane glimmers radiating from your works. \n \n At last, you put up a sign that reads “Magical hand carved masks, for every need, for everyone”.\n";

        }
        else if (readText == 1)
        {
            levelText.fontStyle = FontStyles.Normal;
            levelText.text = "You are a mask maker, an arcane one at that. You expertly craft wooden masks with the purpose of helping folks with their problem, whichever it may be. After being worn for one day, the magical effect will take hold; if the client is satisfied, they will reward you with gold to match your services.";
            
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
}
