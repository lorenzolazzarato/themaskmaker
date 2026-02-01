using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum SelectionPhase
{
    WOOD, FACE, RUNE, DONE
}

public class MaskRenderer : MonoBehaviour
{
    #region PUBLIC
    public SpriteRenderer woodRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer runeRenderer;
    public MaskScript mask;

    public List<MaskWoodType> woodTypeList;
    public List<MaskFaceType> faceTypeList;
    public List<MaskRuneType> runeTypeList;

    public InputSystem_Actions input;


    public static Action<SelectionPhase, MaskScript> updateMaskText;
    public static Action<SelectionPhase> toggleBackButtonVisibility;
    #endregion


    #region PRIVATE
    private SelectionPhase selectionPhase;

    private int faceIndex = 0;
    private int woodIndex = 0;
    private int runeIndex = 0;

    private List<MaskFaceType> compatibleFaces;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI confirmButtonText;
    #endregion



    public void Start()
    {
        // setup a default mask to start with
        mask = new MaskScript(); // Placeholder for actual mask initialization
        mask.woodType = woodTypeList[0];
        mask.faceType = faceTypeList[0];
        mask.runeType = runeTypeList[0];

        selectionPhase = SelectionPhase.WOOD;
        updateMaskText?.Invoke(selectionPhase, mask);

        SetActiveRenderers();
        SetRendererSprites();
    }

    public void ChangeOptionOnClick(int value)
    {
        switch(selectionPhase)
        {
            case SelectionPhase.WOOD:
                woodIndex += value;
                if (woodIndex < 0)
                    woodIndex = woodTypeList.Count - 1;
                woodIndex = woodIndex % woodTypeList.Count;
                mask.woodType = woodTypeList[woodIndex];

                Debug.Log($"Wood id: {mask.woodType.id}, wood name: {mask.woodType.displayName}");
                break;
            case SelectionPhase.FACE:
                faceIndex += value;
                if (faceIndex < 0)
                    faceIndex = compatibleFaces.Count - 1;
                faceIndex = faceIndex % compatibleFaces.Count;
                mask.faceType = compatibleFaces[faceIndex];

                Debug.Log($"Face id: {mask.faceType.id}, face name: {mask.faceType.displayName}");
                break;
            case SelectionPhase.RUNE:
                runeIndex += value;
                if (runeIndex < 0)
                    runeIndex = runeTypeList.Count - 1;
                runeIndex = runeIndex % runeTypeList.Count;
                mask.runeType = runeTypeList[runeIndex];
                break;
        }
        SetRendererSprites();

        updateMaskText?.Invoke(selectionPhase, mask);
    }

    private void SelectFaceFromWood(int woodId)
    {
        compatibleFaces = faceTypeList.GetRange(woodId * 3, 3); // hardcoded number of faces but good enough for demo
    }

    private void SetActiveRenderers()
    {
        switch(selectionPhase)
        {
            case SelectionPhase.WOOD:
                woodRenderer.gameObject.SetActive(true);
                faceRenderer.gameObject.SetActive(false);
                runeRenderer.gameObject.SetActive(false);
                break;
            case SelectionPhase.FACE:
                woodRenderer.gameObject.SetActive(true);
                faceRenderer.gameObject.SetActive(true);
                runeRenderer.gameObject.SetActive(false);
                break;
            case SelectionPhase.RUNE:
                woodRenderer.gameObject.SetActive(true);
                faceRenderer.gameObject.SetActive(true);
                runeRenderer.gameObject.SetActive(true);
                break;
        }
    }

    private void SetRendererSprites()
    {
        woodRenderer.sprite = mask.woodType.sprite;
        faceRenderer.sprite = mask.faceType.sprite;
        runeRenderer.sprite = mask.runeType.sprite;
    }

    public void ConfirmButtonPressed()
    {
        AudioManager.instance.Play("clickbutton");
        switch(selectionPhase)
        {
            case SelectionPhase.WOOD:
                int woodId = woodTypeList[woodIndex].id;
                SelectFaceFromWood(woodIndex);
                faceIndex = 0;
                mask.faceType = compatibleFaces[faceIndex];
                selectionPhase = SelectionPhase.FACE;
                break;
            case SelectionPhase.FACE:
                runeIndex = 0;
                mask.runeType = runeTypeList[runeIndex];
                selectionPhase = SelectionPhase.RUNE;


                break;
            case SelectionPhase.RUNE:
                selectionPhase = SelectionPhase.DONE;
                Debug.Log("Mask creation done!");

                GameManager.mask = mask;
                SceneManager.LoadScene("JudgeScene");
                break;
        }

        toggleBackButtonVisibility?.Invoke(selectionPhase);
        updateMaskText?.Invoke(selectionPhase, mask);
        SetActiveRenderers();
        SetRendererSprites();
    }

    public void UpdateConfirmButtonText()
    {
       if(selectionPhase == SelectionPhase.RUNE)
       {
           confirmButtonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", "ui_button_text_confirm");
       }
       else
       {
           confirmButtonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", "ui_button_text_next");
       }
    }


    public void BackButtonPressed()
    {
        AudioManager.instance.Play("clickbutton");
        switch(selectionPhase)
        {
        case SelectionPhase.FACE:
            selectionPhase = SelectionPhase.WOOD;
            break;
        case SelectionPhase.RUNE:
            selectionPhase = SelectionPhase.FACE;
            break;
        }
        toggleBackButtonVisibility?.Invoke(selectionPhase);
        updateMaskText?.Invoke(selectionPhase, mask);
        SetActiveRenderers();
    }

    public void BackToMenu()
    {
        AudioManager.instance.Play("clickbutton");
        if (GameManager.clientId.userID == 0)
        {
            AudioManager.instance.Stop("catherine");
        }
        else if (GameManager.clientId.userID == 1)
        {
            AudioManager.instance.Stop("alphonse");
        }
        else
        {
            AudioManager.instance.Stop("urian");
        }
        SceneManager.LoadScene(0);
    }

}
