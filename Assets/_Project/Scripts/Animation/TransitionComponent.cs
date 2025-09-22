using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class TransitionComponent : MonoBehaviour
{
    public event System.Action TransitionCompleted;

    [SerializeField]
    private Animator _animator;
    public Animator Animator => _animator;

    [SerializeField]
    private UnityEvent _transitionStarted;

    private void Awake()
    {
        if (!_animator)
        {
            _animator = GetComponent<Animator>();
        }   
    }

    public void SetTriggerParameter(AnimatorParameterHasher parameterHash)
    {
        if (parameterHash.ParameterType != AnimatorControllerParameterType.Trigger)
        {
            Debug.LogError($"Parameter {parameterHash.ParameterName} in {parameterHash.name} is not of type Trigger.");
            return;
        }

        _animator.SetTrigger(parameterHash.ParameterHash);
    }

    public void OnTransitionStarted()
    {
        _transitionStarted?.Invoke();
    }

    public void OnTransitionCompleted()
    {
        TransitionCompleted?.Invoke();
    }
}
