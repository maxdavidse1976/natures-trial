using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event System.Action OnTimerIterationComplete;

    [Header("Configuration")]
    [SerializeField, Tooltip("Duration in seconds of the timer before an iteration is considered complete")]
    private float _duration = 5.0f;
    [SerializeField]
    private bool _loop = false;

    [Header("Events")]
    [SerializeField]
    private UnityEvent _onTimerIterationComplete;

    private float _time;

    public float Duration => _duration;
    public float TimeElapsed => _time;
    public float TimeRemaining => _duration - Mathf.Clamp(_time, 0, _duration);    

    private void Update()
    {
        if (_time < _duration)
        {
            _time += Time.deltaTime;
            if (_time >= _duration)
            {
                _onTimerIterationComplete?.Invoke();
                OnTimerIterationComplete?.Invoke();
                if (_loop)
                {
                    _time = 0.0f;
                }
            }
        }
    }
}
