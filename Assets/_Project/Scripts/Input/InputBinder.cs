using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public interface IMoveListener
{
    void OnMoveStart(InputAction.CallbackContext context);
    void OnMovePerformed(InputAction.CallbackContext context);
    void OnMoveCanceled(InputAction.CallbackContext context);
}

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
