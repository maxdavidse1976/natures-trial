using UnityEngine.InputSystem;

public interface IPlantGrassListener
{
    void OnPlantGrassStart(InputAction.CallbackContext context);
    void OnPlantGrassPerformed(InputAction.CallbackContext context);
    void OnPlantGrassCanceled(InputAction.CallbackContext context);
}
