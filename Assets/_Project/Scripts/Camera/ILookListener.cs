using UnityEngine.InputSystem;

public interface ILookListener
{
    void OnLookStart(InputAction.CallbackContext context);
    void OnLookPerformed(InputAction.CallbackContext context);
    void OnLookCanceled(InputAction.CallbackContext context);
}
