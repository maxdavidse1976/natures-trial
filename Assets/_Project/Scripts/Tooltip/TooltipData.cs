using UnityEngine;
using System;

public struct TooltipInformation
{
    public readonly string Title;
    public readonly string Description;

    public TooltipInformation(string title, string description)
    {
        Title = title;
        Description = description;
    }
}

[CreateAssetMenu(fileName = "New TooltipData", menuName = "Scriptable Objects/Tooltip Data")]
public class TooltipData : ScriptableObject
{
    public event Action<TooltipInformation> OnTooltipInformationChanged;
    public event Action OnTooltipShowRequest;
    public event Action OnTooltipHideRequest;

    public TooltipInformation TooltipInformation => _cacheTooltipInformation;
    private TooltipInformation _cacheTooltipInformation = new TooltipInformation("Test Title", "Very cool sample description");

    public void SetTooltipInformation(string title, string description)
    {
        _cacheTooltipInformation = new TooltipInformation(title, description);
        OnTooltipInformationChanged?.Invoke(_cacheTooltipInformation);  
    }

    private void OnDisable()
    {
        OnTooltipHideRequest = null;
        OnTooltipShowRequest = null;
        OnTooltipInformationChanged = null;
    }

    [ContextMenu("Test Show Tooltip")]
    public void RequestShowTooltip()
    {
        OnTooltipShowRequest?.Invoke();
    }

    [ContextMenu("Test Hide Tooltip")]
    public void RequestHideTooltip()
    {
        OnTooltipHideRequest?.Invoke();
    }   
}
