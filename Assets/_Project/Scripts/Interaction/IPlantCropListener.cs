using UnityEngine.InputSystem;

public interface IPlantCropListener
{
    void OnPlantCropStart(InputAction.CallbackContext context);
    void OnPlantCropPerformed(InputAction.CallbackContext context);
    void OnPlantCropCanceled(InputAction.CallbackContext context);
}
