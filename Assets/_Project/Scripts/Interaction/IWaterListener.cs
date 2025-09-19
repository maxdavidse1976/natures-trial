using UnityEngine.InputSystem;

public interface IWaterListener
{
    void OnWaterStart(InputAction.CallbackContext context);
    void OnWaterPerformed(InputAction.CallbackContext context);
    void OnWaterCanceled(InputAction.CallbackContext context);
}
