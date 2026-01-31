using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using System.Collections.Generic;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] Button menuButton, prevButton, nextButton;
    [SerializeField] LocalizeStringEvent localizeEvent;
    
    [SerializeField] List<LocalizedString> localizedStrings = new List<LocalizedString>();
    private int currentIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuButton.onClick.AddListener(backToMenu);
        prevButton.onClick.AddListener(switchTextBack);
        nextButton.onClick.AddListener(switchTextForw);
        
        switchTextSet(0);
        
    }
    
    void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    void switchTextSet(int setIndex)
    {
    	int index = SetString(localizedStrings, currentIndex);
        if(index != -1)
        {
	     currentIndex = index;
        }
    }
    
    void switchTextForw()
    {
    	int index = SetString(localizedStrings, currentIndex + 1);
        if(index != -1)
        {
	     currentIndex = index;
        }
    }
    
    void switchTextBack()
    {
    	int index = SetString(localizedStrings, currentIndex - 1);
        if(index != -1)
        {
	     currentIndex = index;
        }
    }
    
    int SetString(List<LocalizedString> localizedStrings, int index)
    {
        if (index >= 0 && index < localizedStrings.Count)
        {
    	    localizeEvent.StringReference = localizedStrings[index];
    	    return index;
    	}
    	
    	return -1;
    }
    
    void SetKey(string tableName, string keyName)
    {    
        localizeEvent.StringReference.TableReference = tableName;
        localizeEvent.StringReference.TableEntryReference = keyName;
        localizeEvent.RefreshString();
    }
    
}
