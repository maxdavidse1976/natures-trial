using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerCharacterPlantGrassComponent : MonoBehaviour, IPlantGrassListener
{
    [SerializeField] Camera _playerCamera;
    [SerializeField] float _interactRange = 3f;
    [SerializeField] InputBinder _inputBinder;

    SoilTile _currentTile;


    void Awake()
    {
        this.AssertReference(_inputBinder);
    }

    void Start()
    {
        _inputBinder?.AddPlantGrassListener(this);
    }

    void OnDisable()
    {
        _inputBinder?.RemovePlantGrassListener(this);
    }

    void HidePrompt()
    {
        // Clear the UI message
    }

    #region IPlantGrassListener Interface
    public void OnPlantGrassStart(InputAction.CallbackContext context)
    {
    }

    public void OnPlantGrassPerformed(InputAction.CallbackContext context)
    {
        if (_currentTile != null)
        {
            _currentTile.PlantGrass();
        }
    }

    public void OnPlantGrassCanceled(InputAction.CallbackContext context)
    {
    }
    #endregion
}
