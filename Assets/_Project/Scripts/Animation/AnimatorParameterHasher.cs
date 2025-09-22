using UnityEngine;

[CreateAssetMenu(fileName = "New AnimatorParameterHasher", menuName = "Scriptable Objects/Animator Parameter Hasher")]
public class AnimatorParameterHasher : ScriptableObject
{
    [SerializeField]
    private AnimatorControllerParameterType _parameterType;
    public AnimatorControllerParameterType ParameterType => _parameterType;

    [SerializeField]
    private string _parameterName;
    public string ParameterName => _parameterName;

    private int? _cachedHash = null;
    public int ParameterHash =>  _cachedHash == null ? (int)(_cachedHash = Animator.StringToHash(_parameterName)) : (int)_cachedHash;

    public bool DoesAnimatorHaveParameter(Animator animator)
    {
        foreach (var parameter in animator.parameters)
        {
            if (parameter.nameHash == ParameterHash)
            {
                return parameter.type == _parameterType;
            }
        }
        return false;
    }
}
