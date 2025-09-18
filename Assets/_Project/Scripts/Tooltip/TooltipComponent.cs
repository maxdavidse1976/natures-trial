using UnityEngine;
using Utils;

public class TooltipComponent : MonoBehaviour, ILookHoverer
{
    [SerializeField]
    private TooltipData _tooltipData;

    [SerializeField]
    private string _tooltipTitle;
    [SerializeField, TextArea]
    private string _tooltipDescription;

    private void Awake()
    {
        this.AssertReference(_tooltipData);
    }

    public void OnLookHoverEnter()
    {
        _tooltipData.SetTooltipInformation(_tooltipTitle, _tooltipDescription);
        _tooltipData.RequestShowTooltip();
    }

    public void OnLookHoverExit()
    {
        _tooltipData.RequestHideTooltip();
    }
}   
