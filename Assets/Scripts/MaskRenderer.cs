using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

enum SelectionPhase
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
    #endregion


    #region PRIVATE
    private SelectionPhase selectionPhase = SelectionPhase.WOOD;

    private int faceIndex = 0;
    private int woodIndex = 0;
    private int runeIndex = 0;

    private List<MaskFaceType> compatibleFaces; 
    #endregion


    public void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    public void Start()
    {
        // Initial rendering can be done here if needed
        mask = new MaskScript(); // Placeholder for actual mask initialization
        mask.woodType = woodTypeList[0];
        mask.faceType = faceTypeList[0];
        woodRenderer.sprite = mask.woodType.sprite;
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
                mask.runeType = runeTypeList[runeIndex % runeTypeList.Count];
                break;
        }
        woodRenderer.sprite = mask.woodType.sprite;
        faceRenderer.sprite = mask.faceType.sprite;
        //runeRenderer.sprite = mask.runeType.sprite;
    }

    private void SelectFaceFromWood(int woodId)
    {
        compatibleFaces = faceTypeList.GetRange(woodId * 3, 3); // hardcoded number of faces but good enough for demo
    }

    private void EnableRenderers()
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

    public void ConfirmButtonPressed()
    {
        switch(selectionPhase)
        {
            case SelectionPhase.WOOD:
                int woodId = woodTypeList[woodIndex].id;
                SelectFaceFromWood(woodIndex);
                faceIndex = 0;
                mask.faceType = compatibleFaces[faceIndex];
                selectionPhase = SelectionPhase.FACE;
                faceRenderer.sprite = compatibleFaces[faceIndex].sprite;
                break;
            case SelectionPhase.FACE:
                runeIndex = 0;
                mask.runeType = runeTypeList[runeIndex];
                selectionPhase = SelectionPhase.RUNE;
                break;
            case SelectionPhase.RUNE:
                selectionPhase = SelectionPhase.DONE;
                Debug.Log("Mask creation done!");
                break;
        }
        EnableRenderers();
    }


    public void BackButtonPressed()
    {
        switch(selectionPhase)
        {
        case SelectionPhase.FACE:
            selectionPhase = SelectionPhase.WOOD;
            break;
        case SelectionPhase.RUNE:
            selectionPhase = SelectionPhase.FACE;
            break;
        }
        EnableRenderers();
    }
}
