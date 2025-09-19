using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class SceneLoadingComponent : MonoBehaviour
{
    [SerializeField]
    private SceneData _sceneData;
    private bool _isLoading = false;

    private void Awake()
    {
        this.AssertReference(_sceneData);
    }

    public void StartLoadingLevel()
    {
        if (_isLoading)
        {
            return;
        }

        _isLoading = true;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneData.SceneName);
        asyncLoad.completed += OnAsyncLoadCompleted;
    }

    private void OnAsyncLoadCompleted(AsyncOperation operation)
    {
        Debug.Log("Scene loading completed.");
    }
}
