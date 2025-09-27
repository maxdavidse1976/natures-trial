using UnityEngine;
using UnityEngine.Events;
using System;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class WinConditionComponent : MonoBehaviour
{
    [SerializeReference]
    private WinCondition _winCondition;

    [SerializeField]
    private UnityEvent _onWin;
    [SerializeField]
    private UnityEvent _onLose;

    private void Awake()
    {
        _winCondition?.OnAwake();
    }

    public void CheckWinCondition()
    {
        if (_winCondition != null)
        {
            if (_winCondition.IsConditionMet())
            {
                _onWin?.Invoke();
            }
            else
            {
                _onLose?.Invoke();
            }
        }
    }
}


public abstract class WinCondition
{
    public virtual void OnAwake() { }

    public abstract bool IsConditionMet();
}

[Serializable]
public class DustBowlWinCondition : WinCondition
{
#if UNITY_EDITOR
    [MenuItem("CONTEXT/WinConditionComponent/Set Dust Bowl Win Condition")]
    static void SetDustBowlWinCondition(MenuCommand command)
    {
        // Set the selected win condition component to use DustBowlWinCondition in the SerializedReference field
        var component = (WinConditionComponent)command.context;
        component.GetType()
            .GetField("_winCondition", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(component, new DustBowlWinCondition());
        EditorUtility.SetDirty(component);
    }
#endif

    [SerializeField]
    private FarmlandManager _farmlandManager;

    [SerializeField]
    private int _requiredAlivePlants = 5;

    public override void OnAwake()
    {
        if (_farmlandManager == null)
        {
            throw new NullReferenceException($"Dust Bowl Win Condition is missing the Farmland Manager reference, please set it.");
        }
    }

    public override bool IsConditionMet()
    {
        return _farmlandManager != null && _farmlandManager.ActivePlantCount >= _requiredAlivePlants;
    }
}   