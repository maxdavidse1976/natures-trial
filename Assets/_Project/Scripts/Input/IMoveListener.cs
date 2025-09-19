using UnityEngine.InputSystem;

public interface IMoveListener
{
    void OnMoveCanceled(InputAction.CallbackContext context);
    void OnMovePerformed(InputAction.CallbackContext context);
    void OnMoveStart(InputAction.CallbackContext context);
}