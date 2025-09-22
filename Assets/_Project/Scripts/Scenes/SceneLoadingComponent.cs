using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class SceneLoadingComponent : MonoBehaviour
{
    [SerializeField]
    private SceneData _sceneData;

    [Header("Transition")]
    [SerializeField]
    private TransitionComponent _transitionAnimator;
    [SerializeField]
    private AnimatorParameterHasher _transitionTrigger;

    private bool _isLoading = false;

    private void Awake()
    {
        this.AssertReference(_sceneData);
        this.AssertReference(_transitionAnimator);
        this.AssertReference(_transitionTrigger);
    }

    public void StartLoadingLevel()
    {
        if (_isLoading)
        {
            return;
        }

        _isLoading = true;
        _transitionAnimator.TransitionCompleted += OnTransitionCompleted;
        _transitionAnimator.SetTriggerParameter(_transitionTrigger);
    }


    private void OnTransitionCompleted()
    {
        _transitionAnimator.TransitionCompleted -= OnTransitionCompleted;
        AsyncLoadLevel();
    }

    private void AsyncLoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneData.SceneName);
        asyncLoad.completed += OnAsyncLoadCompleted;
    }

    private void OnAsyncLoadCompleted(AsyncOperation operation)
    {
        Debug.Log("Scene loading completed.");
    }

    [ContextMenu("Verify Parameter")]
    private void VerifyParameter()
    {
        if (!_transitionAnimator)
        {
            Debug.LogWarning("No transition animator assigned.");
            return;
        }

        if (!_transitionTrigger)
        {
            Debug.LogWarning("No transition trigger assigned.");
            return;
        }

        if (!_transitionTrigger.DoesAnimatorHaveParameter(_transitionAnimator.Animator))
        {
            Debug.LogError($"{_transitionAnimator.name} does not have the transition parameter {_transitionTrigger.ParameterName}. Verify parameter name, type or animator parameters.");
            return;
        }

        Debug.Log($"Successfully found the transition parameter {_transitionTrigger.ParameterName} in {_transitionAnimator.name}.");
    }
}
