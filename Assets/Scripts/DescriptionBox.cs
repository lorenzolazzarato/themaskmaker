using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using System.Collections.Generic;

public class DescriptionBox : MonoBehaviour
{
    [SerializeField] Button prevButton, nextButton;
    [SerializeField] LocalizeStringEvent localizeEvent;
    [SerializeField] List<LocalizedString> localizedStrings = new List<LocalizedString>();

    private int currentIndex = 0;

    void Start()
    {
        prevButton.onClick.AddListener(switchTextBack);
        nextButton.onClick.AddListener(switchTextForw);

        CheckVisibility();
        SwitchTextSet(0);
    }

    public void CheckVisibility()
    {
        bool activeStatus = localizedStrings.Count > 1;

        prevButton.gameObject.SetActive(activeStatus);
        nextButton.gameObject.SetActive(activeStatus);
    }

    void SwitchTextSet(int setIndex)
    {
        int index = SetString(setIndex);
        if (index != -1)
        {
            currentIndex = index;
        }
    }

    void switchTextForw()
    {
        int index = SetString(currentIndex + 1);
        if (index != -1)
        {
            currentIndex = index;
        }
    }

    void switchTextBack()
    {
        int index = SetString(currentIndex - 1);
        if (index != -1)
        {
            currentIndex = index;
        }
    }

    int SetString(int index)
    {
        if (index >= 0 && index < localizedStrings.Count)
        {
            localizeEvent.StringReference = localizedStrings[index];
            localizeEvent.RefreshString();
            return index;
        }

        return -1;
    }
}
