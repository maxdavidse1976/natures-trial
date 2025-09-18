using TMPro;
using UnityEngine;
using Utils;

public class TooltipUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleText;

    [SerializeField]
    private TMP_Text _descriptionText;

    [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private TooltipData _tooltipData;

    private void Awake()
    {
        this.AssertReference(_tooltipData);
        this.AssertReference(_titleText);
        this.AssertReference(_descriptionText);
        this.AssertReference(_canvasGroup);

        _tooltipData.OnTooltipShowRequest += ShowTooltip;
        _tooltipData.OnTooltipHideRequest += HideTooltip;
        _tooltipData.OnTooltipInformationChanged += UpdateTooltipInformation;
    }

    private void UpdateTooltipInformation(TooltipInformation information)
    {
        _descriptionText.text = information.Description;
        _titleText.text = information.Title;
    }

    private void HideTooltip()
    {
        _canvasGroup.alpha = 0;
    }

    private void ShowTooltip()
    {
        _canvasGroup.alpha = 1;
    }
}
