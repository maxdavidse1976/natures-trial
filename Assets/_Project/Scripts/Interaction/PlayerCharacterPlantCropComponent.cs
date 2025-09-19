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

    void CheckForTile()
    {
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactRange))
        {
            SoilTile tile = hit.collider.GetComponent<SoilTile>();
            if (tile != null) 
            { 
                _currentTile = tile;
                ShowPrompt();
                return;
            }
        }

        _currentTile = null;
        HidePrompt();
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
        CheckForTile();
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
