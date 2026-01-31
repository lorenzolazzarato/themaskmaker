using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class MaskUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI maskPartTitle;
    [SerializeField]
    private TextMeshProUGUI maskPartDesc;

    

    public void OnEnable()
    {
        MaskRenderer.updateMaskText += SetMaskPartText;
    }

    public void OnDisable()
    {
        MaskRenderer.updateMaskText -= SetMaskPartText;
    }

    private void SetMaskPartText(SelectionPhase selectionPhase, MaskScript mask)
    {
        // which part of the process are we in?
        switch (selectionPhase)
        {
            case SelectionPhase.WOOD:
                maskPartTitle.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"wood_{mask.woodType.id}");
                maskPartDesc.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"wood_{mask.woodType.id}_description");
                break;
            case SelectionPhase.FACE:
                maskPartTitle.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"expression_{mask.faceType.id}");
                maskPartDesc.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"expression_{mask.faceType.id}_description");
                break;
            case SelectionPhase.RUNE:
                maskPartTitle.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"rune_{mask.runeType.id}");
                maskPartDesc.text = LocalizationSettings.StringDatabase.GetLocalizedString("Tabella di prova", $"rune_{mask.runeType.id}_description");
                break;
        }
    }
}
