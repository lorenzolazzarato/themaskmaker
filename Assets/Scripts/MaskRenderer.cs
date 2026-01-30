using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

enum SelectionPhase
{
    WOOD, EYES, ACC, DONE
}

public class MaskRenderer : MonoBehaviour
{
    public SpriteRenderer woodRenderer;
    public SpriteRenderer eyesRenderer;
    public SpriteRenderer accRenderer;
    public MaskScript mask;

    [SerializeField]
    public List<MaskWoodType> woodTypeList;

    public InputSystem_Actions input;

    public int index = 0;

    private SelectionPhase selectionPhase = SelectionPhase.WOOD;

    public void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
        input.Prova.Newaction.performed += ChangeWood;
    }

    public void Start()
    {
        // Initial rendering can be done here if needed
        mask = new MaskScript(); // Placeholder for actual mask initialization
        mask.woodType = woodTypeList[0];
        woodRenderer.sprite = mask.woodType.sprite;
    }
    

    public void ChangeWood(InputAction.CallbackContext ctx)
    {
        mask.woodType = woodTypeList[index++ % woodTypeList.Count];
        //Render(mask);
    }

    public void ChangeWoodClick(int value)
    {
        index += value;

        switch(selectionPhase)
        {
            case SelectionPhase.WOOD:
                mask.woodType = woodTypeList[index % woodTypeList.Count];
                break;
            case SelectionPhase.EYES:

                break;
            case SelectionPhase.ACC:
                break;
        }

        woodRenderer.sprite = mask.woodType.sprite;
    }
}
