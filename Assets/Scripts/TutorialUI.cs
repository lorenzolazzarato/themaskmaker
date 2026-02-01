using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] Button menuButton;
    
    void Start()
    {
        menuButton.onClick.AddListener(backToMenu);
    }
    
    void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
