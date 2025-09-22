using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerCharacterPlantCropComponent : MonoBehaviour, IPlantCropListener
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
        _inputBinder?.AddPlantCropListener(this);
    }

    void OnDisable()
    {
        _inputBinder?.RemovePlantCropListener(this);
    }

    void ShowPrompt()
    {
        // We need to hook this up to UI System still
        Debug.Log("Looking at soil: Press [1] Plant Crop, [2] Plant Grass, [3] Water");
    }

    void HidePrompt()
    {
        // Clear the UI message
    }

    #region IPlantCropListener Interface
    public void OnPlantCropStart(InputAction.CallbackContext context)
    {
    }

    public void OnPlantCropPerformed(InputAction.CallbackContext context)
    {
        if (_currentTile != null)
        {
            _currentTile.PlantCrop();
        }
    }

    public void OnPlantCropCanceled(InputAction.CallbackContext context)
    {
        
    }
    #endregion
}
