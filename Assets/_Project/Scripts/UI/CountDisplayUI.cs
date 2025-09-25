using TMPro;
using UnityEngine;
using Utils;

public class CountDisplayUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    [Header("Configuration")]
    [SerializeField]
    private int _startCount;
    [SerializeField]
    private bool _isClamped;
    [SerializeField]
    private Vector2Int _clampRange;

    private int _internalCount;
    private int _count
    {
        get => _internalCount;
        set => SetCount(value);
    }

    private void Awake()
    {
        _count = _startCount;
        this.AssertReference(_text);
    }

    public void ReduceCount()
    {
        _count--;
        SetTextToCount();
    }

    public void IncreaseCount()
    {
        _count++;
        SetTextToCount();
    }

    private void SetTextToCount()
    {
        _text.text = _count.ToString();
    }

    private void SetCount(int value)
    {
        if (_isClamped)
        {
            _internalCount = Mathf.Clamp(value, _clampRange.x, _clampRange.y);
        }
        else
        {
            _internalCount = value;
        }
    }
}
