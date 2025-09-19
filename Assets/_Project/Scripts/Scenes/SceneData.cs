using UnityEngine;

[CreateAssetMenu(fileName = "New SceneData", menuName = "Scriptable Objects/Scene Data")]
public class SceneData : ScriptableObject
{
    [SerializeField]
    private string _sceneName;
    public string SceneName => _sceneName;
}
