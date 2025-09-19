using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class InputBinder : MonoBehaviour, IPlayerActions, IUIActions
{
    [SerializeField]
    private UnityEvent _interactAction;
    
    private InputSystem_Actions _inputActions;
    private PlayerActions _playerInputs;
    private UIActions _uiInputs;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _playerInputs = new PlayerActions(_inputActions);
        _uiInputs = new UIActions(_inputActions);
        _playerInputs.SetCallbacks(this);
        _uiInputs.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
        _uiInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
        _uiInputs.Disable();
    }

    #region Individual Listeners

    public void AddMoveListener(IMoveListener listener)
    {
        _playerInputs.Move.started += listener.OnMoveStart;
        _playerInputs.Move.performed += listener.OnMovePerformed;
        _playerInputs.Move.canceled += listener.OnMoveCanceled;
    }

    public void RemoveMoveListener(IMoveListener listener)
    {
        _playerInputs.Move.started -= listener.OnMoveStart;
        _playerInputs.Move.performed -= listener.OnMovePerformed;
        _playerInputs.Move.canceled -= listener.OnMoveCanceled;
    }

    public void AddLookListener(ILookListener listener)
    {
        _playerInputs.Look.started += listener.OnLookStart;
        _playerInputs.Look.performed += listener.OnLookPerformed;
        _playerInputs.Look.canceled += listener.OnLookCanceled;
    }

    public void RemoveLookListener(ILookListener listener)
    {
        _playerInputs.Look.started -= listener.OnLookStart;
        _playerInputs.Look.performed -= listener.OnLookPerformed;
        _playerInputs.Look.canceled -= listener.OnLookCanceled;
    }

    public void AddPlantCropListener(IPlantCropListener listener)
    {
        _playerInputs.PlantCrop.started += listener.OnPlantCropStart;
        _playerInputs.PlantCrop.performed += listener.OnPlantCropPerformed;
        _playerInputs.PlantCrop.canceled += listener.OnPlantCropCanceled;
    }

    public void RemovePlantCropListener(IPlantCropListener listener)
    {
        _playerInputs.PlantCrop.started -= listener.OnPlantCropStart;
        _playerInputs.PlantCrop.performed -= listener.OnPlantCropPerformed;
        _playerInputs.PlantCrop.canceled -= listener.OnPlantCropCanceled;
    }

    public void AddPlantGrassListener(IPlantGrassListener listener)
    {
        _playerInputs.PlantGrass.started += listener.OnPlantGrassStart;
        _playerInputs.PlantGrass.performed += listener.OnPlantGrassPerformed;
        _playerInputs.PlantGrass.canceled += listener.OnPlantGrassCanceled;
    }

    public void RemovePlantGrassListener(IPlantGrassListener listener)
    {
        _playerInputs.PlantGrass.started -= listener.OnPlantGrassStart;
        _playerInputs.PlantGrass.performed -= listener.OnPlantGrassPerformed;
        _playerInputs.PlantGrass.canceled -= listener.OnPlantGrassCanceled;
    }

    public void AddWaterListener(IWaterListener listener)
    {
        _playerInputs.Water.started += listener.OnWaterStart;
        _playerInputs.Water.performed += listener.OnWaterPerformed;
        _playerInputs.Water.canceled += listener.OnWaterCanceled;
    }

    public void RemoveWaterListener(IWaterListener listener)
    {
        _playerInputs.Water.started -= listener.OnWaterStart;
        _playerInputs.Water.performed -= listener.OnWaterPerformed;
        _playerInputs.Water.canceled -= listener.OnWaterCanceled;
    }

    #endregion

    #region IPlayerActions Interface

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        _interactAction?.Invoke();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        
    }

    public void OnNext(InputAction.CallbackContext context)
    {

    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }

    public void OnPlantCrop(InputAction.CallbackContext context)
    {

    }

    public void OnPlantGrass(InputAction.CallbackContext context)
    {

    }

    public void OnWater(InputAction.CallbackContext context)
    {

    }

    #endregion

    #region IUIActions Interface

    public void OnNavigate(InputAction.CallbackContext context)
    {
        
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
     
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
       
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
     
    }

    public void OnClick(InputAction.CallbackContext context)
    {

    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
      
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
     
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
      
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
     
    }


    #endregion
}
